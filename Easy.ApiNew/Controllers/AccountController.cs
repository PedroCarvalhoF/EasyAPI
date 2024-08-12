using Easy.Api.Tools;
using Easy.Services.CQRS.User.Command;
using Easy.Services.CQRS.User.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [AllowAnonymous]
    [HttpPost("create-user")]
    public async Task<ActionResult<RequestResult<UsuarioCadastroResponse>>> CadastrarUsuario(UserCreateCommand command)
    {
        return new ReturnActionResult<UserDtoCreateResult>().ParseToActionResult(await _mediator.Send(command));
    }
    [AllowAnonymous]
    [HttpPut]
    public async Task<ActionResult<RequestResult<UserDtoUpdateSenhaResult>>> AlterarSenha([FromBody] AlterarSenhaUserCommand command)
    {
        return new ReturnActionResult<UserDtoUpdateSenhaResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<RequestResult<UsuarioLoginResponse>>> Login([FromBody] UserLoginCommand command)
    {
        try
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {

                UsuarioLoginResponse response = new UsuarioLoginResponse();
                response.AdicionarErro(ex.Message);

                return RequestResult<UsuarioLoginResponse>.BadRequest(ex.Message);
            }

        }
        catch (Exception ex)
        {

            return new ReturnActionResult<UsuarioLoginResponse>().BadRequest(ex.Message);
        }

    }

    [AllowAnonymous]
    [HttpGet("GetUsers")]
    public async Task<ActionResult<RequestResultForUpdate>> GetUsersAsync()
    {
        return await _mediator.Send(new GetUsersQuery());
    }
    [AllowAnonymous]
    [HttpPost("gerar-token-recuperar-senha")]
    public async Task<ActionResult<RequestResult<UserDtoSolicitarTokenResult>>> TokenRecuperacaoSenha([FromBody] SolicitarTokenRecuperacaoSenhaCommand command)
    {
        return new ReturnActionResult<UserDtoSolicitarTokenResult>().ParseToActionResult(await _mediator.Send(command));
    }
    [AllowAnonymous]
    [HttpPost("recuperar-senha")]
    public async Task<ActionResult<RequestResult<UserDtoRecuperarSenhaResult>>> RecuperacaoSenha([FromBody] SolicitarRecuperacaoSenhaCommand command)
    {
        return new ReturnActionResult<UserDtoRecuperarSenhaResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPut("desabilitar-usuario")]
    public async Task<ActionResult<RequestResult<UserDtoHabilitarDesabilitarRequestResult>>> DesabilitarUsuario([FromBody] DesabilitarUserCommand command)
    {
        return new ReturnActionResult<UserDtoHabilitarDesabilitarRequestResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPut("habilitar-usuario")]
    public async Task<ActionResult<RequestResult<UserDtoHabilitarDesabilitarRequestResult>>> HabilitarrUsuario([FromBody] HabilitarUserCommand command)
    {
        return new ReturnActionResult<UserDtoHabilitarDesabilitarRequestResult>().ParseToActionResult(await _mediator.Send(command));
    }

}