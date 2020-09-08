using IExpress.Pagamentos.Domain.DomainObjects;

namespace IExpress.Pagamentos.Domain.Facade
{
    public interface IPagamentoCartaoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento);
    }
}
