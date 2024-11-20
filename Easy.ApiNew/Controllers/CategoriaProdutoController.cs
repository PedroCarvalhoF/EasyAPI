using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.Produto.Categoria.Commands;
using Easy.Services.CQRS.Produto.Categoria.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class CategoriaProdutoController(IMediator _mediator) : ControllerBase
{
    [HttpPost("get-categoria-produto-filter")]
    public async Task<ActionResult<RequestResult<IEnumerable<CategoriaProdutoDto>>>> GetCategoriaProdutoAsync([FromBody] GetCategoriaProdutoEntityFilter command)
    {

        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<CategoriaProdutoDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("get-categoria-produto-dapper")]
    public async Task<ActionResult<RequestResult<IEnumerable<CategoriaProdutoDto>>>> GetCategoriaProdutoDapperAsync([FromBody] GetCategoriaProdutoEntityDapper command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<CategoriaProdutoDto>>().ParseToActionResult(await _mediator.Send(command));
    }
    [HttpPost("cadastrar")]
    public async Task<ActionResult<RequestResult<CategoriaProdutoDto>>> CadastrarCategoriaProdutoAsync([FromBody] CategoriaProdutoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<CategoriaProdutoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut("alterar")]
    public async Task<ActionResult<RequestResult<CategoriaProdutoDto>>> AlterarCategoriaProdutoAsync([FromBody] CategoriaProdutoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<CategoriaProdutoDto>().ParseToActionResult(await _mediator.Send(command));
    }
}