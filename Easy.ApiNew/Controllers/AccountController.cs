using Easy.Api.Tools;
using Easy.Domain.Entities.User;
using Easy.Services.CQRS.User.Command;
using Easy.Services.CQRS.User.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserIdentity;
using Easy.Services.Tools.ImageUrls;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class AccountController(IMediator _mediator) : ControllerBase
{   
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

                UsuarioLoginResponse response = new();
                response.AdicionarErro(ex.Message);

                return RequestResult<UsuarioLoginResponse>.BadRequest(response);
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

    [HttpPut("update-nome-sobrenome")]
    public async Task<ActionResult<RequestResult<UserDto>>> UpdateNomeSobreNome([FromBody] UserCommandUpdateNomeSobreNome command)
    {
        return new ReturnActionResult<UserDto>().ParseToActionResult(await _mediator.Send(command));
    }

    //[AllowAnonymous]
    [HttpPost("upload-image/{userId}")]
    public async Task<ActionResult<RequestResult<UserDtoImageResult>>> UploadImage([FromServices] UserManager<UserEntity> _userManager, [FromServices] IUtil _util, Guid userId)
    {
        try
        {
            if (!Request.HasFormContentType)
            {
                return RequestResult<UserDtoImageResult>.BadRequest("Arquivo não localizado");
            }

            string _destino = "Perfil";
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return NoContent();

            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                _util.DeleteImage(user.ImagemURL, _destino);
                user.AlterarUrlImage(await _util.SaveImage(file, _destino));
            }
            var userRetorno = await _userManager.UpdateAsync(user);

            var userAlterado = await _userManager.FindByEmailAsync(user.Email!);

            var result = new UserDtoImageResult(userAlterado!.Id, userAlterado.ImagemURL!, userAlterado!.Email!);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar realizar upload de Foto do Usuário. Erro: {ex.Message}");
        }
    }

}