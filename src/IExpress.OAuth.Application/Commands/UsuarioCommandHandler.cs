using AutoMapper;
using IExpress.OAuth.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace IExpress.OAuth.Application.Commands
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioCommandHandler> _logger;
        public UsuarioCommandHandler(ILogger<UsuarioCommandHandler> logger, IMapper mapper, UserManager<Usuario> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(AdicionarUsuarioCommand message, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(message);
            usuario.EmailConfirmed = true;
            var retorno = await _userManager.CreateAsync(usuario, message.Password);
            _logger.LogInformation($"Adicionando Usuario {usuario.Id}");
            return retorno.Succeeded;
        }
    }
}
