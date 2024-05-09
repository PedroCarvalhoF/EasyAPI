using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using Domain.Dtos;
using Domain.Dtos.Pedidos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("pedidos")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAll()
        {
            try
            {
                var result = await _pedidoService.GetAll();

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("pedidos/{idPedido}/id")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetPedidoById(Guid idPedido)
        {
            try
            {
                var result = await _pedidoService.Get(idPedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("pedidos/{idPdv}/pdv")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAll(Guid idPdv)
        {
            try
            {
                var result = await _pedidoService.GetAll(idPdv);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("pedidos/{idPdv}/{idCategoria}/categoria-preco")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllByCategoriaPreco(Guid idPdv, Guid idCategoria)
        {
            try
            {
                var result = await _pedidoService.GetAllByCategoriaPreco(idPdv, idCategoria);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("pedidos/{idPdv}/{idSituacao}/situacao-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllBySituacao(Guid idPdv, Guid idSituacao)
        {
            try
            {
                var result = await _pedidoService.GetAllBySituacao(idPdv, idSituacao);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("pedidos/{idPdv}/{idUserCreatePedido}/registro-usuario")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllByUser(Guid idPdv, Guid idUserCreatePedido)
        {
            try
            {
                var result = await _pedidoService.GetAllByUser(idPdv, idUserCreatePedido);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPost("pedidos/gerar-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            try
            {
                var result = await _pedidoService.GerarPedido(pedidoDtoCreate);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPut("pedidos/{idPedido}/encerrar-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> EncerrarPedido(Guid idPedido)
        {
            try
            {
                var result = await _pedidoService.EncerrarPedido(idPedido);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpPut("pedidos/cancelar-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> CancelarPedido(PedidoDtoCancelar pedidoDtoCancelar)
        {
            try
            {
                var result = await _pedidoService.CancelarPedido(pedidoDtoCancelar);
                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

    }
}