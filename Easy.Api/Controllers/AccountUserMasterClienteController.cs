using Easy.Services.CQRS.UserMasterCliente.Command;
using Easy.Services.CQRS.UserMasterCliente.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountUserMasterClienteController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountUserMasterClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserMasterClienteCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserMasterClienteAsync()
    {
        var command = new UserMasterClienteGetUsersMastersClientes();
        return Ok(await _mediator.Send(command));
    }
}
