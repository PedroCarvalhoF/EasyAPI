using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    class CategoriaPrecoController : ControllerBase
    {
        private readonly ICategoriaPrecoService _categoriaPrecoService;
        public CategoriaPrecoController(ICategoriaPrecoService categoriaPrecoService)
        {
            _categoriaPrecoService = categoriaPrecoService;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] CategoriaPrecoDtoCreate categoriaPrecoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CategoriaPrecoDtoCreateResult result = await _categoriaPrecoService.Cadastrar(categoriaPrecoDtoCreate);
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

        [HttpGet("consultar-todas")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<CategoriaPrecoDto> result = await _categoriaPrecoService.ConsultarTodos();
                if (result == null)
                    return BadRequest("Não foi possível realizar tarefa");
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