using Api.Extensions;
using Application.UseCases.Commands.PontoVenda;
using Application.UseCases.Handlers.PontoVenda;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    [Authorize]
    public class PontoVendaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] PontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpGet("{pontoVendaId}/")]
        public async Task<ActionResult> GetById(Guid pontoVendaId, [FromServices] PontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.GetById(pontoVendaId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PontoVendaCreateCommand create, [FromServices] PontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PontoVendaEncerrarCommand update, [FromServices] PontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }


    }
}
