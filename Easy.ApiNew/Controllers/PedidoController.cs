using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.Pdv.Commands;
using Easy.Services.CQRS.PDV.Pdv.Queries;
using Easy.Services.CQRS.PDV.Pedido.Commands;
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

    //[HttpGet]
    //public async Task<ActionResult<RequestResult>> SelectAsync()
    //{
    //    GetPontoVendaQuery command = new GetPontoVendaQuery();
    //    command.SetUsers(User.GetUserMasterUserDatalhes());
    //    return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    //}

    //[HttpGet("filtro/")]
    //public async Task<ActionResult<RequestResult>> SelectAsync([FromBody] GetPontoVendaQueryPdvFilter command)
    //{
    //    command.SetUsers(User.GetUserMasterUserDatalhes());
    //    return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    //}

    [HttpPost]
    public async Task<ActionResult<RequestResult>> CreateAsync([FromBody] PedidoVendaCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cancelar-pedido")]
    public async Task<ActionResult<RequestResult>> CancelarPedidoAsync([FromBody] PedidoCancelarCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }
}