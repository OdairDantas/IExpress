using IExpress.Pagamentos.Domain.DomainObjects;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.AntiCorruption
{
    public interface IPagamentoCartaoFacade
    {
       Task<Transacao> RealizarPagamento(Pedido pedido, PagamentoCartao pagamento);
    }
}
