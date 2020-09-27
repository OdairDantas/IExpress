using Microsoft.AspNetCore.Identity;

namespace IExpress.OAuth.Domain.DomainObjects
{
    public class Usuario : IdentityUser
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
