using Domain.Dtos;
using Domain.Dtos.ItemPedido;
using Domain.Interfaces.Services.ItemPedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidosItensController : ControllerBase
    {
        private readonly IItemPedidoService _service;

        public PedidosItensController(IItemPedidoService itemPedidoService)
        {
            _service = itemPedidoService;
        }

        [HttpGet("itens-pedido")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> GetAll()
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


        [HttpGet("itens-pedido/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> Get(Guid id)
        {
            try
            {
                var result = await _service.Get(id);

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

        [HttpGet("itens-pedido/{idPedido}/pedido")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> GetByIdPedido(Guid idPedido)
        {
            try
            {
                ResponseDto<List<ItemPedidoDto>> result = await _service.GetByIdPedido(idPedido);

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

        [HttpPost("itens-pedido")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> GerarItemPedido(ItemPedidoDtoCreate itemPedido)
        {
            try
            {
                var result = await _service.GerarItemPedido(itemPedido);

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

        [HttpPut("itens-pedido/{id}/cancelar-item")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> CancelarItemPedido(Guid id)
        {
            try
            {
                var result = await _service.CancelarItemPedido(id);

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
    }
}