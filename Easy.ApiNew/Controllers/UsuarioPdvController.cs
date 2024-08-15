using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.User;
using Easy.Services.CQRS.PDV.UsuarioPdv.Commands;
using Easy.Services.CQRS.PDV.UsuarioPdv.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UsuarioPdv;
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
    public async Task<ActionResult<UserDto>> CadastrarUsuarioAsync([FromBody] UsuarioPdvCommandCreate command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<UserDto>().ParseToActionResult(await _mediator.Send(command));
    }


    [HttpPost("habilitar/")]
    public async Task<ActionResult<UserDto>> DesabilitadrUsuarioPdvAsync([FromBody] UsuarioPdvCommandHabilitarDesabilitar command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<UserDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("filtrar/")]
    public async Task<ActionResult<IEnumerable<UserDto>>> FiltrarUsuarioPdvAsync([FromBody] UsuarioPdvQueryGet command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<UserDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("filtrar/email")]
    public async Task<ActionResult<UsuarioPdvDto>> FiltrarUsuarioPdvAsyncByEmail([FromBody] UsuarioPdvQueryGetByEmail command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<UsuarioPdvDto>().ParseToActionResult(await _mediator.Send(command));
    }

}