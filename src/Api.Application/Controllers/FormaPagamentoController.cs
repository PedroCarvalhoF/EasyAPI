using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Interfaces.Services.FormaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoService _service;

        public FormaPagamentoController(IFormaPagamentoService service)
        {
            _service = service;
        }

        [HttpGet("forma-pagamento")]
        public async Task<ActionResult<RequestResult>> GetAll()
        {
            return await _service.GetAll(User.GetUserMasterUser());
        }

        [HttpGet("forma-pagamento/{id}")]
        public async Task<ActionResult<ResponseDto<List<FormaPagamentoDto>>>> GetById(Guid id)
        {
            try
            {
                var respostaService = await _service.GetById(id, User.GetUserMasterUser());

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
                var respostaService = await _service.Create(formaPagamentoDtoCreate, User.GetUserMasterUser());

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
                var respostaService = await _service.Update(formaPagamentoDtoUpdate, User.GetUserMasterUser());

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
