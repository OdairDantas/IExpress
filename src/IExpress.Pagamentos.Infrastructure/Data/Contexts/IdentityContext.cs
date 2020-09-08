using IExpress.Core.Communication.Mediator;
using IExpress.Pagamentos.Infrastructure.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IExpress.Pagamentos.Infrastructure.Data.Contexts
{
    public class IdentityContext : IdentityDbContext<Usuario>
    {
        public IdentityContext()
        {

        }
        public IMediatorHandler _bus { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options, IMediatorHandler rebusHandler) : base(options)
        {
            _bus = rebusHandler ?? throw new ArgumentNullException(nameof(rebusHandler));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IExpress;Trusted_Connection=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }


    }
}
