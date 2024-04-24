using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.PagamentoPedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    class PagamentoPedidoController : Controller
    {
        private readonly IPagamentoPedidoService _pagamentoPedidoService;

        public PagamentoPedidoController(IPagamentoPedidoService pagamentoPedidoService)
        {
            _pagamentoPedidoService = pagamentoPedidoService;
        }

        [HttpPost("inserir-pagamento-pedido")]
        public async Task<ActionResult> InseririPagamentoPedido([FromBody] PagamentoPedidoDtoCreate pagamentoPedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto result = await _pagamentoPedidoService.InseririPagamentoPedido(pagamentoPedidoDto);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpPost("inserir-pagamento-lote-pedido")]
        public async Task<ActionResult> InseririPagamentoPedidoLote([FromBody] IEnumerable<PagamentoPedidoDtoCreate> pgts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = await _pagamentoPedidoService.InseririPagamentoPedidoLote(pgts);
                if (!result)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpGet("consultar-pagamentos-pedido/{idPedido}")]
        public async Task<ActionResult> ConsultarPagamentosPedidoByIdPedido(Guid idPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PagamentoPedidoDto> dtos = await _pagamentoPedidoService.ConsultarPagamentosPedidoByIdPedido(idPedido);
                if (dtos == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(dtos);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpDelete("remover-pagamento-pedido/{idPagamento}")]
        public async Task<ActionResult> RemoverPagamentosPedidoByIdPagamento(Guid idPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PagamentoPedidoDto> dtos = await _pagamentoPedidoService.RemoverPagamentosPedidoByIdPagamento(idPagamento);
                if (dtos == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(dtos);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }

        [HttpDelete("remover-all-pagamento-pedido/{idPedido}")]
        public async Task<ActionResult> RemoverPagamentosPedidoByIdPedido(Guid idPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = await _pagamentoPedidoService.RemoverPagamentosPedidoByIdPedido(idPedido);
                if (!result)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(result);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }
    }
}
