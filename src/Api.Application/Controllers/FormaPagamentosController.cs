using Domain.Dtos.FormaPagamentoDtos;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces.Services.FormaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    class FormaPagamentosController : ControllerBase
    {
        private readonly IFormaPagamentoService _service;

        public FormaPagamentosController(IFormaPagamentoService service)
        {
            _service = service;
        }


        [HttpPost("cadastrar-forma-pg")]
        public async Task<ActionResult<FormaPagamentoDto>> CadastrarFormaPg([FromBody] FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                FormaPagamentoDto dto = await _service.CadastrarFormaPg(formaPagamentoDtoCreate);
                if (dto == null) BadRequest("Erro inesperado, consulte o suport");
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

        [HttpPut("alterar-forma-pg")]
        public async Task<ActionResult<FormaPagamentoDto>> AlterarFormaPg([FromBody] FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                FormaPagamentoDto dto = await _service.AlterarFormaPg(formaPagamentoDtoUpdate);
                if (dto == null) BadRequest("Erro inesperado, consulte o suport");
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

        [HttpGet("get-all-forma-pg")]
        public async Task<ActionResult<IEnumerable<FormaPagamentoDto>>> GetAll()
        {
            try
            {
                IEnumerable<FormaPagamentoDto> dtos = await _service.GetAll();
                if (dtos == null) BadRequest("Erro inesperado, consulte o suport");
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




    }
}
