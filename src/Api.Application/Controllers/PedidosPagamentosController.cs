using Domain.Dtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Dtos.PedidoPagamento;
using Domain.Interfaces.Services.PagamentoPedido;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PedidosPagamentosController : ControllerBase
    {
        private readonly IPagamentoPedidoService _service;

        public PedidosPagamentosController(IPagamentoPedidoService pagamentoPedidoService)
        {
            _service = pagamentoPedidoService;
        }
        [HttpPost("pagamento-pedido/create")]

        public async Task<ActionResult<ResponseDto<List<PagamentoPedidoDto>>>> CreatePagamentoPedido(PagamentoPedidoDtoCreate pgPedido)
        {
            try
            {
                var result = await _service.CreatePagamentoPedido(pgPedido);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
                response.Erro(ex.Message);

                return BadRequest(response);
            }
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
                ResponseDto<List<ItemPedidoDto>> response = new ResponseDto<List<ItemPedidoDto>>();
                response.Erro(ex.Message);

                return BadRequest(response);
            }
        }
        //public Task<ResponseDto<List<PagamentoPedidoDto>>> GetPagamentoPedidoByIdPedido(Guid pedidoId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseDto<List<PagamentoPedidoDto>>> UpdatePagamentoPedido(PagamentoPedidoDtoUpdate pgUpdate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
