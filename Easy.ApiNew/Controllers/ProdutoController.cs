using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.Produto.Commands;
using Easy.Services.CQRS.Produto.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<RequestResultForUpdate>> GetProdutosAynsc()
    {
        var getCommand = new GetProdutosQuery();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpGet("{idProduto}/")]

    public async Task<ActionResult<RequestResultForUpdate>> GetProdutoByIdAsync(Guid idProduto)
    {
        var getCommand = new GetProdutoByIdQuery();
        getCommand.IdProduto = idProduto;
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CadastraProdutoAsync([FromBody] ProdutoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<RequestResultForUpdate>> AlterarProdutoAsync([FromBody] ProdutoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }


}