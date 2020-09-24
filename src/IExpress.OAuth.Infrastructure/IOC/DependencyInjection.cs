using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IExpress.OAuth.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection DependencyResolve(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
