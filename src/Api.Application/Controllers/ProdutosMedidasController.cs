using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosMedidasController : ControllerBase
    {
        private readonly IProdutoMedidaServices _produtoMedidaServices;

        public ProdutosMedidasController(IProdutoMedidaServices produtoMedidaServices)
        {
            _produtoMedidaServices = produtoMedidaServices;
        }



        [HttpGet("medidas-produtos")]
        public async Task<ActionResult<IEnumerable<ProdutoMedidaDto>>> GetAll()
        {
            try
            {
                var dtos = await _produtoMedidaServices.GetAll();
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

        [HttpGet("medidas-produtos/{id}/id")]
        public async Task<ActionResult<ProdutoMedidaDto>> Get(Guid id)
        {
            try
            {
                var dto = await _produtoMedidaServices.Get(id);
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



        [HttpGet("medidas-produtos/{descricao}/descricao")]
        public async Task<ActionResult<IEnumerable<ProdutoMedidaDto>>> Get(string descricao)
        {
            try
            {
                var dtos = await _produtoMedidaServices.Get(descricao);
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


        [HttpPost("medidas-produtos/create")]
        public async Task<ActionResult<ProdutoMedidaDto>> Post(ProdutoMedidaDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
               var dto = await _produtoMedidaServices.Create(create);
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



        [HttpPut("medidas-produtos/update")]
        public async Task<ActionResult<ProdutoMedidaDto>> Update(ProdutoMedidaDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dto = await _produtoMedidaServices.Update(update);
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

    }
}
