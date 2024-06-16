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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return new ReturnActionResult().ParseToActionResult(
                await _service.GetAll(User.GetUserMasterUser()),
                User.GetUserMasterUserDatalhes());
        }

        [HttpGet("{formaPagamentoId}")]
        public async Task<ActionResult> GetById(Guid formaPagamentoId)
        {
            return new ReturnActionResult().ParseToActionResult(await _service.GetById(formaPagamentoId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new ReturnActionResult().ParseToActionResult(await _service.Create(formaPagamentoDtoCreate, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
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
