using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutosCategoriasPrecosController : ControllerBase
    {
        private readonly ICategoriaPrecoService _service;
        public ProdutosCategoriasPrecosController(ICategoriaPrecoService categoriaPrecoService)
        {
            _service = categoriaPrecoService;
        }


        [HttpGet("categorias-precos")]
        public async Task<ActionResult<IEnumerable<CategoriaPrecoDto>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<CategoriaPrecoDto> result = await _service.GetAll();
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

        [HttpGet("categorias-precos/{id}/id")]
        public async Task<ActionResult<CategoriaPrecoDto>> Get(Guid id)
        {
            try
            {
                CategoriaPrecoDto dto = await _service.Get(id);
                if (dto == null)
                {
                    return BadRequest("Não localizado");
                }
                return Ok(dto);
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

        [HttpPost("cadastrar-categorias-precos")]
        public async Task<ActionResult> Cadastrar(CategoriaPrecoDtoCreate categoriaPrecoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CategoriaPrecoDto result = await _service.Create(categoriaPrecoDtoCreate);
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

        [HttpPut("alterar-categorias-precos")]
        public async Task<ActionResult<CategoriaPrecoDto>> Update(CategoriaPrecoDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                CategoriaPrecoDto dto = await _service.Update(update);
                if (dto == null)
                {
                    return BadRequest("Não foi possível realizar tafefa");
                }
                return Ok(dto);
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

        [HttpPut("desabilitar/categorias-precos/{id}")]
        public async Task<ActionResult> Desabilitar(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool result = await _service.Desabilitar(id);
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