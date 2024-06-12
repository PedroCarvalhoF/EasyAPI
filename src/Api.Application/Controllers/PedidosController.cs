using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.Pedido;
using Domain.Dtos.Pedidos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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



        //CONSULTAS POR PDVS
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

        [HttpGet("pedidos/{idPdv}/pdv-clean")]
        public async Task<ActionResult<ResponseDto<List<PedidoDtoClean>>>> GetAllCleanTeste(Guid idPdv)
        {
            try
            {
                var result = await _pedidoService.GetAllCleanTeste(idPdv);

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<List<PedidoDtoClean>>().Erro(ex));
            }
        }



        [HttpGet("pedidos/{idPdv}/{numeroPedido}/numero-pedido-contains")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllByPdvByNumeroPedidoContains(Guid idPdv, string numeroPedido)
        {
            try
            {
                var result = await _pedidoService.GetAllByPdvByNumeroPedidoContains(idPdv, numeroPedido);

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

        [HttpGet("pedidos/{idPdv}/{idFormaPagamento}/pagamento")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllByPagamento(Guid idPdv, Guid idFormaPagamento)
        {
            try
            {
                var result = await _pedidoService.GetAllByPagamento(idPdv, idFormaPagamento);

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

        [HttpGet("pedidos/{idPdv}/{idProduto}/produto")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GetAllByPdvByProdutoAsync(Guid idPdv, Guid idProduto)
        {
            try
            {
                var result = await _pedidoService.GetAllByPdvByProdutoAsync(idPdv, idProduto);

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

        //MÉTODOS
        [HttpPost("pedidos/gerar-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                pedidoDtoCreate.UserRegistroId = User.GetUserId();

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


        [HttpPut("pedidos/atualizar-valor-pedido")]
        public async Task<ActionResult<ResponseDto<List<PedidoDto>>>> AtualizarValorPedido(Guid idPedido)
        {
            try
            {
                var result = await _pedidoService.AtualizarValorPedido(idPedido);
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