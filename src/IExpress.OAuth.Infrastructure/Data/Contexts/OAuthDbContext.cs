using IExpress.OAuth.Domain.DomainObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IExpress.OAuth.Infrastructure.Data.Contexts
{
    public class OAuthDbContext : IdentityDbContext<Usuario>
    {
        public OAuthDbContext(DbContextOptions<OAuthDbContext> options) : base(options)
        { }
    }
}
