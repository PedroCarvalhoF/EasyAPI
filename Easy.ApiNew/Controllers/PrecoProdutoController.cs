using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.PrecoProduto.Commands;
using Easy.Services.CQRS.PDV.PrecoProduto.Queries;
using Easy.Services.DTOs.PrecoProduto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class PrecoProdutoController : ControllerBase
{
    private readonly IMediator _mediator;
    public PrecoProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<PrecoProdutoDtoView>> CreateAsync([FromBody] PrecoProdutoCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PrecoProdutoDtoView>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<List<PrecoProdutoDtoView>>> GetPrecosProdutosAynsc()
    {
        var getCommand = new GetPrecosProdutosQuery();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<List<PrecoProdutoDtoView>>().ParseToActionResult(await _mediator.Send(getCommand));
    }

    [HttpGet("{idProduto}")]
    public async Task<ActionResult<List<PrecoProdutoDtoView>>> GetPrecoProdutoByIdProduto(Guid idProduto)
    {
        var getCommand = new GetPrecoProdutoByProduto();
        getCommand.IdProduto = idProduto;
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<List<PrecoProdutoDtoView>>().ParseToActionResult(await _mediator.Send(getCommand));
    }
}