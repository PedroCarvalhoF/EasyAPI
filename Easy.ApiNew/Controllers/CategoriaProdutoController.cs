using Easy.Api.Extensions;
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
public class CategoriaProdutoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriaProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<RequestResult<IEnumerable<CategoriaProdutoView>>>> GetCategoriasProdutos()
    {
        var getCommand = new GetCategoriaProdutoQuery();
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpGet("{idCategoria}")]
    public async Task<ActionResult<RequestResult<CategoriaProdutoView>>> GetCategoriaProdutudoByIdCategoria(Guid idCategoria)
    {
        var getCommand = new GetCategoriaProdutoQueryById(idCategoria);
        getCommand.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CadastrarCategoria([FromBody] CategoriaProdutoCreateCommand command)
    {
        command.SetFiltro(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<RequestResult<CategoriaProdutoView>>> AlterarCategoria([FromBody] CategoriaProdutoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(command);
    }


}