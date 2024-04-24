using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.ItemPedido;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.ItemPedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService itemPedidoService;

        public ItemPedidoController(IItemPedidoService itemPedidoService)
        {
            this.itemPedidoService = itemPedidoService;
        }

        [HttpPost("item-pedido-registrar")]
        public async Task<ActionResult> ResgistrarItem([FromBody] ItemPedidoDtoCreate itemPedidoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ItemPedidoDto result = await itemPedidoService.RegistrarItemPedido(itemPedidoCreate);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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

        [HttpPost("item-pedido-registrar-return-pedido")]
        public async Task<ActionResult> ResgistrarItemReturnPedido([FromBody] ItemPedidoDtoCreate itemPedidoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto pedidoDto = await itemPedidoService.ResgistrarItemReturnPedido(itemPedidoCreate);
                if (pedidoDto == null)
                    return BadRequest("Não foi possível realizar operação.");
                return Ok(pedidoDto);
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


        [HttpPut("cancelar-item/{idItemPedido}")]
        public async Task<ActionResult> CancelarItemPedido(Guid idItemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ItemPedidoDto result = await itemPedidoService.CancelarItemPedido(idItemPedido);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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

        [HttpPut("cancelar-item-return-pedido/{idItemPedido}")]
        public async Task<ActionResult> CancelarItemPedidoReturnPedido(Guid idItemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto result = await itemPedidoService.CancelarItemPedidoReturnPedido(idItemPedido);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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




        [HttpGet("item-pedido-get-id/{idItemPedido}")]
        public async Task<ActionResult> GetByIdItemPedido(Guid idItemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ItemPedidoDto result = await itemPedidoService.GetByIdItemPedido(idItemPedido);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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


        [HttpGet("item-pedido-by-produto/{idProduto}/fullConsulta")]
        public async Task<ActionResult> GetByIdProduto(Guid idProduto, bool fullConsulta = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<ItemPedidoDto> result = await itemPedidoService.GetByIdProduto(idProduto, fullConsulta);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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


        [HttpGet("item-pedido-by-produto/{situacaoItem}")]
        public async Task<ActionResult> GetBySituacaoItem(int situacaoItem, bool fullConsulta = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<ItemPedidoDto> result = await itemPedidoService.GetBySituacaoItem(situacaoItem, fullConsulta);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
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
