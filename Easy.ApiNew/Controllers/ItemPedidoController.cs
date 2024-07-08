using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.ItemPedido.Commands;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class ItemPedidoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ItemPedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CreateAsync([FromBody] ItemPedidoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cancelar-item")]
    public async Task<ActionResult<RequestResultForUpdate>> CreateAsync([FromBody] ItemPedidoCancelarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("aplicar-desconto-item")]
    public async Task<ActionResult<RequestResultForUpdate>> AplicarDescontoItemAsync([FromBody] ItemPedidoAplicarDescontoCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }
}