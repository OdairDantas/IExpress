using IExpress.Core.Messages;

namespace IExpress.OAuth.Application.Commands
{
    public class AdicionarUsuarioCommand : Command
    {
        public AdicionarUsuarioCommand(string nome, string email, string password, double latitude, double longitude)
        {
            Nome = nome;
            Email = email;
            Password = password;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
