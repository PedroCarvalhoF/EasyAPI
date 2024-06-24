using Easy.Api.Extensions;
using Easy.Services.CQRS.Produto.Categoria.Commands;
using Easy.Services.CQRS.Produto.Categoria.Queries;
using Easy.Services.DTOs;
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
    public async Task<ActionResult<RequestResult>> CadastrarUsuario()
    {
        var getCommand = new GetCategoriasQuery();
        getCommand.SetFiltro(User.GetUserMasterUserDatalhes());        
        return await _mediator.Send(getCommand);
    }

    [HttpPost]
    public async Task<ActionResult<RequestResult>> CadastrarUsuario([FromBody] CategoriaProdutoCreateCommand command)
    {
        command.SetFiltro(User.GetUserMasterUserDatalhes());
        return await _mediator.Send(command);
    }


}