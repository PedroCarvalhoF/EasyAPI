using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.CategoriaPreco.Commands;
using Easy.Services.CQRS.PDV.CategoriaPreco.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class CategoriaPrecoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriaPrecoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaPrecoDto>>> GetCategoriasPrecosAsync()
    {
        var getCommand = new GetCategoriasPrecosQueries();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<CategoriaPrecoDto>>().ParseToActionResult(await _mediator.Send(getCommand));
    }

    [HttpGet("by-id")]

    public async Task<ActionResult<RequestResult<CategoriaPrecoDto>>> GetByIdAsync([FromBody] GetCategoriaPrecoByIdQuery command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<CategoriaPrecoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost]
    public async Task<ActionResult<RequestResult<CategoriaPrecoDto>>> CreateAsync([FromBody] CategoriaPrecoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<CategoriaPrecoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResult<CategoriaPrecoDto>>> UpdateAsync([FromBody] CategoriaPrecoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<CategoriaPrecoDto>().ParseToActionResult(await _mediator.Send(command));
    }
}