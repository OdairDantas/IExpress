using IExpress.Core.ValueObjects;
using System;

namespace IExpress.Pagamentos.Domain.DomainObjects.DTO
{
    public class PagamentoPedido
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Total { get; set; }
        public Cartao Cartao{ get; set; }
    }
}
