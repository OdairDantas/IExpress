using IExpress.OAuth.Domain.DomainObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IExpress.OAuth.Infrastructure.Data.Contexts
{
    public class OAuthDbContext : IdentityDbContext<Usuario>
    {



        public OAuthDbContext(DbContextOptions<OAuthDbContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Ignore<Event>();
            builder.HasDefaultSchema("Security");
            builder.ApplyConfigurationsFromAssembly(typeof(OAuthDbContext).Assembly);
            
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(builder);
        }

    }
}
