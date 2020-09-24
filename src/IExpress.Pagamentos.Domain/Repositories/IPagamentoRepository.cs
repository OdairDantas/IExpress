using IExpress.Core.Data;
using IExpress.Pagamentos.Domain.DomainObjects;

namespace IExpress.Pagamentos.Domain.Repositories
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {

        void AdicionarTransacao(Transacao transacao);
    }
}
