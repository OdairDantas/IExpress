using System;


namespace IExpress.Pagamentos.Application.ViewModels
{
    public class PagamentoPedidoViewModel
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Total { get; set; }
        public string TitularCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public int CvvCartao { get; set; }
    }
}
