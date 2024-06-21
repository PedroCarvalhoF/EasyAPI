using Easy.Services.CQRS.UserMasterUser.Command;
using Easy.Services.CQRS.UserMasterUser.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountUserMasterUserController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountUserMasterUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserMasterUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var get = new UserMasterUserGetAllAsync();
        return Ok(await _mediator.Send(get));
    }
}
