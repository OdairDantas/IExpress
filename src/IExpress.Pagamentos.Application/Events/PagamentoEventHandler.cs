using AutoMapper;
using IExpress.Core.Messages.CommonMessages.IntegrationEvents;
using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.DomainObjects.DTO;
using IExpress.Pagamentos.Domain.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.Application.Events
{
    public class PagamentoEventHandler : INotificationHandler<PedidoEstoqueConfirmadoEvent>
    {

        private readonly IPagamentoAppService _pagamentoService;
        private readonly IMapper _mapper;

        public PagamentoEventHandler(IPagamentoAppService pagamentoService, IMapper  mapper)
        {
            _pagamentoService = pagamentoService;
            _mapper = mapper;
        }

        public async Task Handle(PedidoEstoqueConfirmadoEvent message, CancellationToken cancellationToken)
        {
            var pagamentoPedido = new PagamentoPedido
            {
                PedidoId = message.PedidoId,
                ClienteId = message.ClienteId,
                Total = message.Total,
                Cartao = message.Cartao
            };

            await _pagamentoService.RealizarPagamentoPedido(_mapper.Map<PagamentoPedidoViewModel>(pagamentoPedido));
        }
    }
}
