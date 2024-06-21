using Easy.Api.Tools;
using Easy.Services.CQRS.User.Command;
using Easy.Services.CQRS.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
//[Authorize]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("CadastraUsuario")]
    public async Task<ActionResult> Cadastrar([FromBody] UserCreateCommand create)
    {
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(create));
    }

    [AllowAnonymous]
    [HttpPost("AlterarSenhaUsuario")]
    public async Task<ActionResult> AlterarSenha([FromBody] AlterarSenhaUserCommand updateSenha)
    {
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(updateSenha));
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] UserLoginCommand login)
    {
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(login));
    }

    [HttpGet]
    public async Task<ActionResult> GetUsersAsync()
    {
        var getUser = new GetUsersQuery();
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(getUser));
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult> GetUserByIdAsync(Guid id)
    {
        var getUser = new GetUserByIdQuery(id);
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(getUser));
    }

    [HttpGet("by-email/{email}")]
    public async Task<ActionResult> GetUserByEmailAsync(string email)
    {
        var getUser = new GetUserByEmailQuery(email);
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(getUser));
    }

}
