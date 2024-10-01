using Easy.Api.Tools;
using Easy.Services.CQRS.UserMasterCliente.Command;
using Easy.Services.CQRS.UserMasterCliente.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]

public class AccountsUserClienteController(IMediator mediator) : ControllerBase
{
    [HttpPost("cadastrar-cliente")]
    public async Task<ActionResult<RequestResultForUpdate>> CadastrarUserCliente([FromBody] UserMasterClienteCreateCommand command)
    {
        return new ReturnActionResultForUpdate().ParseToActionResult(await mediator.Send(command));
    }
    [AllowAnonymous]
    [HttpGet("get-clientes")]
    public async Task<ActionResult<RequestResultForUpdate>> CadastrarUserCliente()
    {
        return new ReturnActionResultForUpdate().ParseToActionResult(await mediator.Send(new GetUserMasterClienteQuery()));
    }

}