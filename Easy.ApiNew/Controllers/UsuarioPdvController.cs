using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Services.CQRS.PDV.UsuarioPdv.Commands;
using Easy.Services.CQRS.PDV.UsuarioPdv.Queries;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class UsuarioPdvController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsuarioPdvController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<RequestResultForUpdate>> CadastrarUsuarioAsync([FromBody] UsuarioPdvCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }


    [HttpPost("habilitar/")]
    public async Task<ActionResult<RequestResultForUpdate>> DesabilitadrUsuarioPdvAsync([FromBody] UsuarioPdvDesabilitarHabilitarCommand command)
    {

        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("filtrar/")]
    public async Task<ActionResult<RequestResultForUpdate>> FiltrarUsuarioPdvAsync([FromBody] GetUsuarioPdv command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResultForUpdate().ParseToActionResult(await _mediator.Send(command));
    }

}