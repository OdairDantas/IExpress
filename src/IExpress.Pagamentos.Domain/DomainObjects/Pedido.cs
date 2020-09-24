using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class Pedido
    {
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(10, 2)")]

        public decimal Valor { get; set; }
    }
}
