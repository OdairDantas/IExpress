using IExpress.Pagamentos.Application.ViewModels;
using IExpress.Pagamentos.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IExpress.WebApps.API.Pagamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {

        private readonly IPagamentoAppService _pagamentoAppService;


        public PagamentoController(IPagamentoAppService pagamentoAppService)
        {
            _pagamentoAppService = pagamentoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPagamentoPedido(PagamentoPedidoViewModel pagamentoPedido)
        {
            var transacao = await _pagamentoAppService.RealizarPagamentoPedido(pagamentoPedido);

            return Ok(new { Transacao = transacao.Id, Status = transacao.StatusTransacao });


        }
    }
}
