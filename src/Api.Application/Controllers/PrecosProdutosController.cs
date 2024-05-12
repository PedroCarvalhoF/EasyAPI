using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Domain.Dtos;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PrecosProdutosController : Controller
    {
        private readonly IPrecoProdutoService _service;
        public PrecosProdutosController(IPrecoProdutoService service)
        {
            _service = service;
        }

        [HttpGet("precos-produtos")]
        public async Task<ActionResult<ResponseDto<List<PrecoProdutoDto>>>> GetAll()
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
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("precos-produtos/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<PrecoProdutoDto>>>> Get(Guid id)
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
                ResponseDto<List<PedidoDto>> response = new ResponseDto<List<PedidoDto>>();
                response.Dados = new List<PedidoDto>();
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return BadRequest(response);
            }
        }

        [HttpGet("precos-produtos/{id}/produto-id")]
        public async Task<ActionResult<ResponseDto<List<PrecoProdutoDto>>>> GetProdutoId(Guid id)
        {
            try
            {
                var result = await _service.GetProdutoId(id);

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

        [HttpGet("precos-produtos/{id}/categoria-preco-id")]
        public async Task<ActionResult<ResponseDto<List<PrecoProdutoDto>>>> GetCategoriaPrecoId(Guid id)
        {
            try
            {
                var result = await _service.GetCategoriaPrecoId(id);

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



        [HttpPost("CreateUpdate/precos-produtos")]
        public async Task<ActionResult<PrecoProdutoDto>> CreateUpdate(PrecoProdutoDtoCreate create)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.CreateUpdate(create);

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