using Domain.Dtos.ProdutoTipo;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.ProdutoTipo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosTipoController : ControllerBase
    {
        private readonly IProdutoTipoServices _services;

        public ProdutosTipoController(IProdutoTipoServices services)
        {
            _services = services;
        }


        [HttpGet("tipos-produtos")]
        public async Task<ActionResult<IEnumerable<ProdutoTipoDto>>> GetAll()
        {
            try
            {
                IEnumerable<ProdutoTipoDto> dtos = await _services.GetAll();
                if (dtos == null)
                {
                    return BadRequest("Não localizado");
                }
                return Ok(dtos);
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

        [HttpGet("tipos-produtos/{id}/id")]
        public async Task<ActionResult<ProdutoTipoDto>> Get(Guid id)
        {
            try
            {
                ProdutoTipoDto dto = await _services.Get(id);
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



        [HttpGet("tipos-produtos/{descricao}")]
        public async Task<ActionResult<IEnumerable<ProdutoTipoDto>>> Get(string descricao)
        {
            try
            {
                IEnumerable<ProdutoTipoDto> dtos = await _services.Get(descricao);
                if (dtos == null)
                {
                    return BadRequest("Não localizado");
                }
                return Ok(dtos);
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


        [HttpPost("cadastrar-tipos-produtos")]
        public async Task<ActionResult<ProdutoTipoDto>> Post(ProdutoTipoDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ProdutoTipoDto dto = await _services.Create(create);
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

        [HttpPut("alterar-tipos-produtos")]
        public async Task<ActionResult<ProdutoTipoDto>> Update(ProdutoTipoDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ProdutoTipoDto dto = await _services.Update(update);
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

        [HttpPut("tipos-produtos/{id}/desabilitar")]
        public async Task<ActionResult<bool>> Desabilitar(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool dto = await _services.Desabilitar(id);
                if (!dto)
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

    }
}
