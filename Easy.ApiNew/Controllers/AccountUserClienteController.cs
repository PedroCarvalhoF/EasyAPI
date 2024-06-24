using Easy.Api.Tools;
using Easy.Services.CQRS.UserMasterCliente.Command;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]

public class AccountsUserClienteController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountsUserClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("cadastrar-cliente")]
    public async Task<ActionResult<RequestResult>> CadastrarUserCliente([FromBody] UserMasterClienteCreateCommand command)
    {
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

}