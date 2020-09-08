using IExpress.Core.ValueObjects;
using System;

namespace IExpress.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoEstoqueConfirmadoEvent : IntegrationEvent
    {

        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal Total { get; private set; }
        public Cartao Cartao { get; private set; }

        public PedidoEstoqueConfirmadoEvent(Guid pedidoId, Guid clienteId, decimal total, Cartao cartao )
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            Total = total;
            Cartao = cartao;
        }
    }
}
