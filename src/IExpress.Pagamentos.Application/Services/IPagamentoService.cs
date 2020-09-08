using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.DomainObjects;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.Domain.Service
{
    public interface IPagamentoAppService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedidoViewModel pagamentoPedido);

    }
}
