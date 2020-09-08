using IExpress.Core.DomainObjects;
using IExpress.Pagamentos.Domain.Enumerators;
using System;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class Transacao: Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }

        // EF. Rel.
        public Pagamento Pagamento { get; set; }
    }
}
