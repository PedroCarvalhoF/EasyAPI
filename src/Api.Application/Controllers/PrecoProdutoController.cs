using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    
    class PrecoProdutoController : ControllerBase
    {
        private readonly IPrecoProdutoService _service;
        public PrecoProdutoController(IPrecoProdutoService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar-alterar-preco-produto")]
        public async Task<ActionResult> CadastrarPrecoProduto([FromBody] PrecoProdutoDtoCreate precoProdutoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PrecoProdutoDto? produtoDto = await _service.CadastrarPrecoProduto(precoProdutoDtoCreate);
                if (produtoDto == null) BadRequest("Não foi possíve realizar cadastro.");
                return Ok(produtoDto);
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

        //CONSULTAR ALL PRECOS PRODUTOS INCLUDE
        [HttpGet("get-all-precos-produtos")]
        public async Task<ActionResult> ConsultarPrecoProduto()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PrecoProdutoDto> precos = await _service.ConsultarPrecoProduto();
                return Ok(precos);
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

        //CONSULTAR PRECOS POR CATEGORIA DE PREÇO
        [HttpGet("get-precos-by-categoria-preco/{categoriaId}")]
        public async Task<ActionResult> GetPrecosByCategoriaPrecoID(Guid categoriaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PrecoProdutoDto> precos = await _service.GetPrecosByCategoriaPrecoID(categoriaId);
                return Ok(precos);
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


        //CONSULTAR PRECOs POR PRODUTO 
        [HttpGet("get-precos-by-produto/{produtoId}")]
        public async Task<ActionResult> GetPrecosByProdutoID(Guid produtoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PrecoProdutoDto> precos = await _service.GetPrecosByProdutoID(produtoId);
                return Ok(precos);
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