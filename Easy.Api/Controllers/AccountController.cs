using Easy.Api.Tools;
using Easy.Services.CQRS.User.Command;
using Easy.Services.CQRS.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("CadastraUsuario")]
    public async Task<ActionResult> Cadastrar([FromBody] CreateUserCommand create)
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
    [HttpGet]
    public async Task<ActionResult> GetUsersAsync()
    {
        var getUser = new GetUsersQuery();
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(getUser));
    }

}
