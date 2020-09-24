using IExpress.Core.Data;
using IExpress.Pagamentos.Domain.DomainObjects;
using IExpress.Pagamentos.Domain.Repositories;
using IExpress.Pagamentos.Infrastructure.Data.Contexts;

namespace IExpress.Pagamentos.Infrastructure.Data.Repositories
{
    public class PagamentoRepository : Repository<Pagamento>,  IPagamentoRepository
    {
        private readonly PagamentoContext _context;

        public PagamentoRepository(PagamentoContext context) :base(context)
        {
            _context = context;
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }
    }
}
