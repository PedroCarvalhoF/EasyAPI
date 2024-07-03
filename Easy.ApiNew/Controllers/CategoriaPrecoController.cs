﻿using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.CategoriaPreco.Commands;
using Easy.Services.CQRS.PDV.CategoriaPreco.Queries;
using Easy.Services.DTOs;
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
    public async Task<ActionResult<RequestResult>> GetAsync()
    {
        var getCommand = new GetCategoriasPrecosQueries();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpGet("{id}/")]

    public async Task<ActionResult<RequestResult>> GetByIdAsync(Guid id)
    {
        var getCommand = new GetCategoriaPrecoByIdQuery();
        getCommand.Id = id;
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResult>> CreateAsync([FromBody] CategoriaPrecoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResult>> UpdateAsync([FromBody] CategoriaPrecoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult().ParseToActionResult(await _mediator.Send(command));
    }
}