using Api.Domain.Dtos.ProdutoMedidaDtos;
using Domain.Dtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Interfaces.Services.PeriodoPontoVenda;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PontoVendasPeriodosController : ControllerBase
    {
        private readonly IPeriodoPontoVendaService _service;

        public PontoVendasPeriodosController(IPeriodoPontoVendaService service)
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
                    return BadRequest(dtos);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
                response.Dados = new List<PeriodoPontoVendaDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("periodos-pontos-vendas/{id}/id")]
        public async Task<ActionResult<PeriodoPontoVendaDto>> Get(Guid id)
        {
            try
            {
                var dtos = await _service.Get(id);
                if (dtos == null)
                    return BadRequest(dtos);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
                response.Dados = new List<PeriodoPontoVendaDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("periodos-pontos-vendas/{descricao}")]
        public async Task<ActionResult<IEnumerable<PeriodoPontoVendaDto>>> Get(string descricao)
        {
            try
            {
                var dtos = await _service.Get(descricao);
                if (dtos == null)
                    return BadRequest(dtos);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
                response.Dados = new List<PeriodoPontoVendaDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }


        [HttpPost("cadastrar-periodos-pontos-vendas")]
        public async Task<ActionResult<ProdutoMedidaDto>> Post(PeriodoPontoVendaDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var dtos = await _service.Create(create);
                if (dtos == null)
                    return BadRequest(dtos);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
                response.Dados = new List<PeriodoPontoVendaDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("desabilitar/periodos-pontos-vendas/{id}")]
        public async Task<ActionResult> Desabilitar(Guid id)
        {           
            try
            {
                var dtos = await _service.Desabilitar(id);
                if (dtos == null)
                    return BadRequest(dtos);

                return Ok(dtos);

            }
            catch (Exception ex)
            {
                ResponseDto<List<PeriodoPontoVendaDto>> response = new ResponseDto<List<PeriodoPontoVendaDto>>();
                response.Dados = new List<PeriodoPontoVendaDto>();
                response.Erro(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
