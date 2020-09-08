using IExpress.Pagamentos.Domain.DomainObjects;
using IExpress.Pagamentos.Domain.Enumerators;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.AntiCorruption
{
    public class PagamentoCartaoFacade : IPagamentoCartaoFacade
    {

        private readonly IPayPalGateway _payPalGateway;
        private readonly IConfigurationManager _configManager;

        public PagamentoCartaoFacade(IPayPalGateway payPalGateway, IConfigurationManager configManager)
        {
            _payPalGateway = payPalGateway;
            _configManager = configManager;
        }

        public async Task<Transacao> RealizarPagamento(Pedido pedido, PagamentoCartao pagamento)
        {
            var apiKey = _configManager.GetValue("apiKey");
            var encriptionKey = _configManager.GetValue("encriptionKey");

            var serviceKey = _payPalGateway.GetPayPalServiceKey(apiKey, encriptionKey);
            var cardHashKey = _payPalGateway.GetCardHashKey(serviceKey, pagamento.Cartao.Numero);

            var pagamentoResult = _payPalGateway.CommitTransaction(cardHashKey, pedido.Id.ToString(), pagamento.Valor);

            // TODO: O gateway de pagamentos que deve retornar o objeto transação
            var transacao = new Transacao
            {
                PedidoId = pedido.Id,
                Total = pedido.Valor,
                PagamentoId = pagamento.Id
            };

            if (pagamentoResult)
            {
                transacao.StatusTransacao = StatusTransacao.Pago;
                return transacao;
            }

            transacao.StatusTransacao = StatusTransacao.Recusado;
            return transacao;
        }
    }
}
