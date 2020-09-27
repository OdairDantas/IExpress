using IExpress.OAuth.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace IExpress.OAuth.Application.Commands
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        public UsuarioCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(AdicionarUsuarioCommand message, CancellationToken cancellationToken)
        {
            var novoUsuario = new Usuario()
            {
                UserName = message.Nome,
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Email = message.Email,
                EmailConfirmed = true

            };
            var retorno = await _userManager.CreateAsync(novoUsuario, message.Password);
            return retorno.Succeeded;
        }
    }
}
