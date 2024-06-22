using Easy.Api.Extensions;
using Easy.Services.CQRS.CategoriaProduto.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoriaProdutoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriaProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoriaProdutoCreateCommand command)
    {
        command.AplicarFiltro(User.GetUserMasterUser());
        return Ok(await _mediator.Send(command));
    }
}
