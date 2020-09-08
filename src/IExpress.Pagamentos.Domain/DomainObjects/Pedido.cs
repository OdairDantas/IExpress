using System;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
    }
}
