using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using Domain.Dtos.PedidoDtos;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        #region Codes Desatualizados
        public PedidosController(IPedidoService produtoService)
        {
            _pedidoService = produtoService;
        }
        [HttpPost("gerar-pedido")]
        public async Task<ActionResult> GerarPedido([FromBody] PedidoDtoCreate pedidoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto pedidoDto = await _pedidoService.GerarPedido(pedidoCreate);
                if (pedidoDto == null) BadRequest("Não foi possíve gerar pedido.");
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


        [HttpPost("pedido-get-by-idPedido/{idPedido}/{fullConsulta}")]
        public async Task<ActionResult> GetByIdPedido(Guid idPedido, bool fullConsulta = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PedidoDto> pedidoDto = await _pedidoService.GetByIdPedido(idPedido, fullConsulta);
                if (pedidoDto == null) BadRequest("Não foi possíve cancelar pedido.");
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


        [HttpPut("encerrar-pedido/{pedidoId}")]
        public async Task<ActionResult> EncerrarPedido(Guid pedidoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto pedidoDto = await _pedidoService.EncerrarPedido(pedidoId);
                if (pedidoDto == null) BadRequest("Não foi possíve encerrar pedido.");
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
        [HttpDelete("cancelar-pedido")]
        public async Task<ActionResult> CancelarPedido([FromBody] PedidoDtoCancelamento dtoCancelamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto pedidoDto = await _pedidoService.CancelarPedido(dtoCancelamento);
                if (pedidoDto == null) BadRequest("Não foi possíve cancelar pedido.");
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

        [HttpPut("atualizar-valor-pedido/{pedidoId}")]
        async Task<ActionResult> AtualizarValorPedido(Guid pedidoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto pedidoDto = await _pedidoService.AtualizarValorPedido(pedidoId);
                if (pedidoDto == null) BadRequest("Não foi possíve cancelar pedido.");
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

        [HttpPut("cancelar-all-item-pedido-return-pedido/{idPedido}")]
        public async Task<ActionResult> CancelarTodosItensPedidoReturnPedido(Guid idPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto result = await _pedidoService.CancelarTodosItensPedidoReturnPedido(idPedido);
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

        #region Gets

        [HttpGet("consultar-pedido-by-situacao/{situacaoPedido}")]
        /// <summary>
        /// Consulta de pedido filtrado de acordo com a situação
        /// 
        /// Aberto = 1,
        /// Finalizado = 2,
        /// Cancelado = 3
        /// </summary>
        public async Task<ActionResult> GetBySituacaoPedido(SituacaoPedidoEnum situacaoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PedidoDto>? pedidoDto = await _pedidoService.Get(situacaoPedido);
                if (pedidoDto == null) BadRequest("Não foi possíve realizar consulta");
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



        [HttpGet("consultar-pedido-by-pdv/{idPdv}")]
        public async Task<ActionResult> GetPdv(Guid idPdv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PedidoDto>? pedidoDto = await _pedidoService.Get(idPdv);
                if (pedidoDto == null) BadRequest("Não foi possíve realizar consulta");
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

        #endregion


        #endregion


        [HttpDelete("remover-all-itens/pedido/{idPedido}")]
        public async Task<ActionResult> RemoverAllItensPedido(Guid idPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PedidoDto result = await _pedidoService.RemoverAllItensPedido(idPedido);
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
