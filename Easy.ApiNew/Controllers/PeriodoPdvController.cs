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
public class PeriodoPdvController : ControllerBase
{
    private readonly IMediator _mediator;
    public PeriodoPdvController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeriodoPdvDto>>> GetPeriodoPdvAsync()
    {
        var command = new GetPeriodoPdvQueries();
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<PeriodoPdvDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("by-id")]

    public async Task<ActionResult<PeriodoPdvDto>> GetPeriodoPdvByIdAsync([FromBody] GetPeriodoPdvByIdQuery command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost]
    public async Task<ActionResult<PeriodoPdvDto>> CreatePeriodoPdvAsync([FromBody] PeriodoPdvCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("habilitar-desabilitar")]
    public async Task<ActionResult<PeriodoPdvDto>> HabilitarDesabilitarPeriodoPdvAsync([FromBody] PeriodoPdvHabilitarDesabilitarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PeriodoPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }
}