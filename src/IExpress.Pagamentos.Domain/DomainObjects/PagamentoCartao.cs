using IExpress.Core.ValueObjects;
using System;

namespace IExpress.Pagamentos.Domain.DomainObjects
{
    public class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(Guid pedidoId, decimal valor, Cartao cartao) : base(pedidoId, valor)
        {
            Cartao = cartao;
        }

        public Cartao Cartao { get; private set; }
    }
}
