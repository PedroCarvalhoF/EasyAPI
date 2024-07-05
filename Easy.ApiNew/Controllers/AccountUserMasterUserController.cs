using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.UserMasterUser.Command;
using Easy.Services.CQRS.UserMasterUser.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]

public class AccountsUserMasterUserController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountsUserMasterUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("cadastrar-usuario")]
    public async Task<ActionResult<RequestResult>> CadastraUsuario([FromBody] UserMasterUserCreateCommand command)
    {
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<RequestResult>> GetUserByClienteIdAsync()
    {
        var command = new GetUserMasterUserQuery();
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

}