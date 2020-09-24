using IExpress.Core.DomainObjects;
using IExpress.Pagamentos.Domain.Enumerators;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class Transacao: Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }

        // EF. Rel.
        public Pagamento Pagamento { get; set; }
    }
}
