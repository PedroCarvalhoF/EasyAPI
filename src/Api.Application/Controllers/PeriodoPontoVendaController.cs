using Api.Extensions;
using Application.UseCases.Commands.PontoVenda.Periodo;
using Application.UseCases.Handlers.PontoVenda.Periodo;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class PeriodoPontoVendaController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] PeriodoPontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.GetAll(User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpGet("{periodoId}/")]
        public async Task<ActionResult> GetById(Guid periodoId, [FromServices] PeriodoPontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.GetById(periodoId, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PeriodoCreateCommand create, [FromServices] PeriodoPontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.Create(create, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PeriodoUpdateCommand update, [FromServices] PeriodoPontoVendaServiceHandler handler)
        {
            return new ReturnActionResult().ParseToActionResult(await handler.Update(update, User.GetUserMasterUser()), User.GetUserMasterUserDatalhes());
        }
    }
}