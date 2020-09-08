using AutoMapper;
using IExpress.Pagamentos.AntiCorruption;
using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.DomainObjects;
using IExpress.Pagamentos.Domain.Service;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.Application.Services
{
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IMapper _mapper;
        private readonly IPagamentoCartaoFacade _pagamentoCartaoFacade;

        public PagamentoAppService(IMapper mapper, IPagamentoCartaoFacade pagamentoCartaoFacade)
        {
            _mapper = mapper;
            _pagamentoCartaoFacade = pagamentoCartaoFacade;
        }

        public async Task<Transacao> RealizarPagamentoPedido(PagamentoPedidoViewModel pagamentoPedido)
        {
            
            return await _pagamentoCartaoFacade.RealizarPagamento(_mapper.Map<Pedido>(pagamentoPedido), _mapper.Map<PagamentoCartao>(pagamentoPedido));
        }
    }
}
