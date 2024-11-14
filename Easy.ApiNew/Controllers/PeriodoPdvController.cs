using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.Periodo.Commands;
using Easy.Services.CQRS.PDV.Periodo.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PeriodoPdvController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<RequestResult<IEnumerable<PeriodoPdvDto>>>> GetPeriodosAsync([FromBody] GetPeriodoPdvFilter command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<PeriodoPdvDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cadastrar-periodo-pdv")]
    public async Task<ActionResult<RequestResult<PeriodoPdvDto>>> CreatePeriodoPdvAsync([FromBody] PeriodoPdvCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResult<PeriodoPdvDto>>> UpdatePeriodoPdvAsync([FromBody] PeriodoPdvUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }
    [HttpPut("habilitar-desabilitar")]
    public async Task<ActionResult<RequestResult<PeriodoPdvDto>>> HabilitarDesabilitarPeriodoPdvAsync([FromBody] PeriodoPdvHabilitarDesabilitarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }
}