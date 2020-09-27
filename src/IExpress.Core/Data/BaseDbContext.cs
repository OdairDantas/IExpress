using IExpress.Core.Communication.Mediator;
using IExpress.Core.Data.Extensions;
using IExpress.Core.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IExpress.Core.Data
{
    public class BaseDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;
        private string _connectionString { get; set; }

        public BaseDbContext()
        {

        }

        public BaseDbContext(string connectionString, DbContextOptions options, IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator;
            _connectionString = connectionString;
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
