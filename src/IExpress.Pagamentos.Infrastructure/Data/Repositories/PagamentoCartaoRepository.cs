using IExpress.Core.Data;
using IExpress.Pagamentos.Domain.DomainObjects;
using IExpress.Pagamentos.Domain.Repositories;
using IExpress.Pagamentos.Infrastructure.Data.Contexts;

namespace IExpress.Pagamentos.Infrastructure.Data.Repositories
{
    public class PagamentoCartaoRepository : IPagamentoCartaoRepository
    {
        private readonly PagamentoContext _context;

        public PagamentoCartaoRepository(PagamentoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public void Adicionar(PagamentoCartao pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
