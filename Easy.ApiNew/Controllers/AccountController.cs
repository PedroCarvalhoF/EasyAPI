using Easy.Services.CQRS.User.Command;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [AllowAnonymous]
    [HttpPost("cadastrar")]
    public async Task<ActionResult<RequestResult>> CadastrarUsuario(UserCreateCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<RequestResult>> Login([FromBody] UserLoginCommand command)
    {
        return await _mediator.Send(command);
    }
}