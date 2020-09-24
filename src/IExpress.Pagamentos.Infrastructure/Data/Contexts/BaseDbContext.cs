using IExpress.Core.Communication.Mediator;
using IExpress.Core.Data;
using IExpress.Core.Messages;
using IExpress.Pagamentos.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IExpress.Pagamentos.Infrastructure.Data.Contexts
{
    public class BaseDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public BaseDbContext()
        {

        }

        public BaseDbContext(DbContextOptions options, IMediatorHandler mediator ) : base(options)
        {
            _mediator = mediator;
        }

        public virtual async Task<bool> Commit()
        {
            var executado = await base.SaveChangesAsync() > 0;

            if (executado) await _mediator.PublicarEventos(this);

            return executado;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
