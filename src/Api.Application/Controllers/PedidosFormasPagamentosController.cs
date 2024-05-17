using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Interfaces.Services.FormaPagamento;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PedidosFormasPagamentosController : ControllerBase
    {
        private readonly IFormaPagamentoService _service;

        public PedidosFormasPagamentosController(IFormaPagamentoService service)
        {
            _service = service;
        }

        [HttpGet("forma-pagamento")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetAll()
        {
            try
            {
                var respostaService = await _service.GetAll();

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }

        }
        [HttpGet("forma-pagamento/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetById(Guid id)
        {
            try
            {
                var respostaService = await _service.GetById(id);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }
        }
        [HttpGet("forma-pagamento/{descricao}/descricao")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetByDescricao(string descricao)
        {
            try
            {
                var respostaService = await _service.GetByDescricao(descricao);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }
        }
        [HttpPost("forma-pagamento/create")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var respostaService = await _service.Create(formaPagamentoDtoCreate);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }
        }
        [HttpPut("forma-pagamento/update")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var respostaService = await _service.Update(formaPagamentoDtoUpdate);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }
        }
        [HttpPut("forma-pagamento/{id}/desabilitar")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> DesabilitarHabilitar(Guid id)
        {
            try
            {
                var respostaService = await _service.DesabilitarHabilitar(id);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<FormaPagamentoDto>>().Erro(ex));
            }
        }

    }
}
