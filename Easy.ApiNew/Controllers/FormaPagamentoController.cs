using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.FormaPagamento.Commands;
using Easy.Services.CQRS.PDV.FormaPagamento.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.FormaPagamento;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class FormaPagamentoController : ControllerBase
{
    private readonly IMediator _mediator;
    public FormaPagamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<RequestResult<IEnumerable<FormaPagamentoDto>>>> GetFormaPagamentoAsync()
    {
        var getCommand = new GetFormaPagamentosQueries();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<FormaPagamentoDto>>().ParseToActionResult(await _mediator.Send(getCommand));
    }

    [HttpGet("{id}/")]

    public async Task<ActionResult<RequestResultForUpdate>> GetByIdAsync(Guid id)
    {
        var getCommand = new GetFormaPagamentoByIdQuery();
        getCommand.Id = id;
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> InserirFormaPagamentoAsync([FromBody] FormaPagamentoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResultForUpdate>> UpdateAsync([FromBody] FormaPagamentoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }


}