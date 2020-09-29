using AutoMapper;
using IExpress.OAuth.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace IExpress.OAuth.Application.Commands
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;
        public UsuarioCommandHandler(IMapper mapper, UserManager<Usuario> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AdicionarUsuarioCommand message, CancellationToken cancellationToken)
        {

            var usuario = _mapper.Map<Usuario>(message);
            usuario.EmailConfirmed = true;
            var retorno = await _userManager.CreateAsync(usuario, message.Password);
            return retorno.Succeeded;
        }
    }
}
