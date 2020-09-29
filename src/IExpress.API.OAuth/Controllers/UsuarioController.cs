using AutoMapper;
using IExpress.Core.Communication.Mediator;
using IExpress.OAuth.Application.Commands;
using IExpress.OAuth.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IExpress.API.OAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        public UsuarioController(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(AdicionarUsuarioViewModel usuario)
        {

            var retorno = await _mediator.EnviarComando(_mapper.Map<AdicionarUsuarioCommand>(usuario));
            if (!retorno) return BadRequest();

            return CreatedAtAction("AdicionarUsuario", "Sucess");
        }


    }
}
