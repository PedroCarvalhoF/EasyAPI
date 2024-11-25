using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.PrecoProduto.Commands;
using Easy.Services.CQRS.PDV.PrecoProduto.Queries;
using Easy.Services.DTOs;
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

    [HttpPost("get-preco-produto-filter-dapper")]
    public async Task<ActionResult<RequestResult<IEnumerable<PrecoProdutoDto>>>> GetPrecosProdutosAynsc([FromBody] GetPrecoProdutoDapperFilterCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<PrecoProdutoDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cadastrar-alterar")]
    public async Task<ActionResult<RequestResult<PrecoProdutoDto>>> CreateUpdateAsync([FromBody] PrecoProdutoCommandCreate command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<PrecoProdutoDto>().ParseToActionResult(await _mediator.Send(command));
    }
}