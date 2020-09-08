using IExpress.Core.Data;
using IExpress.Pagamentos.Domain.DomainObjects;

namespace IExpress.Pagamentos.Domain.Repositories
{
    public interface IPagamentoCartaoRepository : IRepository<PagamentoCartao>
    {
        void Adicionar(PagamentoCartao pagamento);

        void AdicionarTransacao(Transacao transacao);
    }
}
