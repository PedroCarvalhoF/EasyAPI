using Api.Domain.Dtos.PedidoDtos;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PedidoItem;
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
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
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
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
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
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
            }
        }

        [HttpPost("itens-pedido")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> InserirItemNoPedido(ItemPedidoDtoCreate itemPedido)
        {
            try
            {
                itemPedido.UsuarioPontoVendaEntityId = User.GetUserId();
                var result = await _service.InserirItemNoPedido(itemPedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
            }
        }

        [HttpPost("itens-pedido-return-pedido")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> InserirItemNoPedidoReturnPedido(ItemPedidoDtoCreate itemPedido)
        {
            try
            {
                itemPedido.UsuarioPontoVendaEntityId = User.GetUserId();
                var result = await _service.InserirItemNoPedidoReturnPedido(itemPedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
            }
        }

        [HttpPut("itens-pedido-editar-observacao")]
        public async Task<ActionResult<ResponseDto<List<ItemPedidoDto>>>> EditarObservacao(ItemPedidoDtoEditarObservacao observacao)
        {
            try
            {

                var result = await _service.EditarObservacao(observacao);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
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
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
            }
        }

        [HttpPut("itens-pedido/{idItemPedido}/cancelar-item-return-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> CancelarItemReturnPedido(Guid idItemPedido)
        {
            try
            {
                var result = await _service.CancelarItemReturnPedido(idItemPedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<ItemPedidoDto>>().Erro(ex));
            }
        }

        [HttpDelete("itens-pedido/{idPedido}/remover-all-itens-idPedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> RemoverAllItensByIdPedido(Guid idPedido)
        {
            try
            {
                var result = await _service.RemoverAllItensByIdPedido(idPedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PedidoDto>>().Erro(ex));
            }
        }
    }
}