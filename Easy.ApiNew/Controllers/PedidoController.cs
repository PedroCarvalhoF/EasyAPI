using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.Pedido.Commands;
using Easy.Services.CQRS.PDV.Pedido.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PedidoController : ControllerBase
{
    private readonly IMediator _mediator;
    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("filtro-pedido")]
    public async Task<ActionResult<RequestResultForUpdate>> CreateAsync([FromBody] GetPedidosFilterPedidosQueries command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }


    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CreateAsync([FromBody] PedidoVendaCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cancelar-pedido")]
    public async Task<ActionResult<RequestResultForUpdate>> CancelarPedidoAsync([FromBody] PedidoCancelarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("atualizar-pedido")]
    public async Task<ActionResult<RequestResultForUpdate>> AtualizarPedidoAsync([FromBody] PedidoAtualizarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }
}