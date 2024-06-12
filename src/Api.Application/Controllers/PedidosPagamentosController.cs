using Domain.Dtos;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Interfaces.Services.PagamentoPedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PedidosPagamentosController : ControllerBase
    {
        private readonly IPagamentoPedidoService _service;

        public PedidosPagamentosController(IPagamentoPedidoService pagamentoPedidoService)
        {
            _service = pagamentoPedidoService;
        }

        [HttpGet("pagamento-pedido")]
        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PagamentoPedidoDto>>().Erro(ex));
            }
        }

        [HttpGet("pagamento-pedido/{idPedido}/idPedido")]
        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> GetByIdPedido(Guid idPedido)
        {
            try
            {
                var result = await _service.GetByIdPedido(idPedido);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PagamentoPedidoDto>>().Erro(ex));
            }
        }
        [HttpPost("pagamento-pedido/create")]
        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> InserirPagamentoPedido(PagamentoPedidoDtoCreate pgPedido)
        {
            try
            {
                var result = await _service.InserirPagamentoPedido(pgPedido);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PagamentoPedidoDto>>().Erro(ex));
            }
        }

        [HttpPost("pagamento-pedido/create-array")]
        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> InserirArrayPagamentoPedido(List<PagamentoPedidoDtoCreate> listPagamentoCreate)
        {
            try
            {
                var result = await _service.InserirArrayPagamentoPedido(listPagamentoCreate);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PagamentoPedidoDto>>().Erro(ex));
            }
        }



        [HttpDelete("pagamento-pedido/{idPagamento}/remover-pagamento")]
        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> RemoverPagamentoPedido(Guid idPagamento)
        {
            try
            {
                var result = await _service.RemoverPagamentoPedido(idPagamento);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PagamentoPedidoDto>>().Erro(ex));
            }
        }
    }
}
