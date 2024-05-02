using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutosCategoriasController : ControllerBase
    {
        private readonly ICategoriaProdutoService _categoriaService;
        public ProdutosCategoriasController(ICategoriaProdutoService categoriaProdutoService)
        {
            _categoriaService = categoriaProdutoService;
        }
        [HttpGet("categorias")]
        public async Task<ActionResult> GetAllCategorias()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _categoriaService.Get());
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

        [HttpGet("categoria/{id}/id")]
        public async Task<ActionResult> GetId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _categoriaService.Get(id));
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

        [HttpGet("categorias/{nomeCategoria}")]
        public async Task<ActionResult> GetNomeCategoria(string nomeCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _categoriaService.Get(nomeCategoria));
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

        [HttpPost("cadastrar-categoria-produto")]
        public async Task<ActionResult> Post([FromBody] CategoriaProdutoDtoCreate categoriaCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CategoriaProdutoDto result = await _categoriaService.Create(categoriaCreate);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
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

        [HttpPut("alterar-categoria-produto")]
        public async Task<ActionResult> AlterarCategoria([FromBody] CategoriaProdutoDtoUpdate update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CategoriaProdutoDto result = await _categoriaService.Update(update);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
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

        [HttpPut("desabilitar/{id}")]
        public async Task<ActionResult> Desabilitar(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = await _categoriaService.DesabilitarHabilitar(id);
                if (result)

                    return Ok(result);
                else
                    return BadRequest("Não foi possível realizar alteração");

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
