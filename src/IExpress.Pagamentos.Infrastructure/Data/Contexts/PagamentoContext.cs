using IExpress.Core.Communication.Mediator;
using Microsoft.EntityFrameworkCore;
using IExpress.Pagamentos.Domain.DomainObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using IExpress.Core.Data;

namespace IExpress.Pagamentos.Infrastructure.Data.Contexts
{
    public class PagamentoContext : BaseDbContext
    {
        private readonly IMediatorHandler _mediator;


        public PagamentoContext()
        {

        }
        public PagamentoContext(DbContextOptions<PagamentoContext> options, IMediatorHandler mediator): base("Server=(localdb)\\mssqllocaldb;Database=IExpress;Trusted_Connection=true;",options, mediator)
        {
            _mediator = mediator;
        }

        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        public override async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.Commit();
        }
        
        
    }
}
