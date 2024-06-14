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
        public async Task<ActionResult> GetAll()
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpPost("forma-pagamento/create")]
        public async Task<ActionResult> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new ReturnActionResult().ParseToActionResult(await _service.Create(formaPagamentoDtoCreate, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());


        }
        [HttpPut("forma-pagamento/update")]
        public async Task<ActionResult> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return new ReturnActionResult().ParseToActionResult(await _service.Update(formaPagamentoDtoUpdate, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}
