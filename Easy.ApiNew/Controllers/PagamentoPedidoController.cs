using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.PagamentoPedido.Commands;
using Easy.Services.CQRS.PDV.PagamentoPedido.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PagamentoPedidoController : ControllerBase
{
    private readonly IMediator _mediator;
    public PagamentoPedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<RequestResult>> CreateAsync([FromBody] PagamentoPedidoInserirCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<RequestResult>> PagamentosPedidosAsync()
    {
        var getCommand = new GetPagamentoPedidoQuery();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(getCommand));
    }
}