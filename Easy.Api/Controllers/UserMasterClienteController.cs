using Easy.Domain.Intefaces;
using Easy.Services.CQRS.UserMasterCliente.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserMasterClienteController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserMasterClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserMasterClienteCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

}
