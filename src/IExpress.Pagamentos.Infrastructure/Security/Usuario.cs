using Microsoft.AspNetCore.Identity;

namespace IExpress.Pagamentos.Infrastructure.Security
{
    public class Usuario : IdentityUser
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
}
