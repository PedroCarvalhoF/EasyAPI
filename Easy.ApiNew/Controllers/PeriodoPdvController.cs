using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.Periodo.Commands;
using Easy.Services.CQRS.PDV.Periodo.Queries;
using Easy.Services.DTOs;
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
    public async Task<ActionResult<RequestResultForUpdate>> GetAsync()
    {
        var getCommand = new GetPeriodoPdvQueries();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpGet("{id}/")]

    public async Task<ActionResult<RequestResultForUpdate>> GetByIdAsync(Guid id)
    {
        var getCommand = new GetPeriodoPdvByIdQuery();
        getCommand.Id = id;
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CreateAsync([FromBody] PeriodoPdvCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResultForUpdate>> UpdateAsync([FromBody] PeriodoPdvUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }
}