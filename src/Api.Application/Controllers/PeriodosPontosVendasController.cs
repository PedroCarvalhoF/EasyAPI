using Api.Domain.Dtos.ProdutoMedidaDtos;
using Api.Domain.Interfaces.Services.ProdutoMedida;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.PeriodoPontoVenda;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PeriodosPontosVendasController : ControllerBase
    {
        private readonly IPeriodoPontoVendaService _service;

        public PeriodosPontosVendasController(IPeriodoPontoVendaService service)
        {
            _service = service;
        }



        [HttpGet("periodos-pontos-vendas")]
        public async Task<ActionResult<IEnumerable<PeriodoPontoVendaDto>>> GetAll()
        {
            try
            {
                var dtos = await _service.GetAll();
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

        [HttpGet("periodos-pontos-vendas/{id}/id")]
        public async Task<ActionResult<PeriodoPontoVendaDto>> Get(Guid id)
        {
            try
            {
                var dto = await _service.Get(id);
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

        [HttpGet("periodos-pontos-vendas/{descricao}")]
        public async Task<ActionResult<IEnumerable<PeriodoPontoVendaDto>>> Get(string descricao)
        {
            try
            {
                var dtos = await _service.Get(descricao);
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


        [HttpPost("cadastrar-periodos-pontos-vendas")]
        public async Task<ActionResult<ProdutoMedidaDto>> Post(PeriodoPontoVendaDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dto = await _service.Create(create);
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


        [HttpPut("alterar-periodos-pontos-vendas")]
        public async Task<ActionResult<ProdutoMedidaDto>> Update(PeriodoPontoVendaDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dto = await _service.Update(update);
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

        [HttpPut("desabilitar/periodos-pontos-vendas/{id}")]
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
