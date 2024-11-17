using Easy.Api.Tools;
using Easy.Services.CQRS.User.Command;
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
public class AccountController(IMediator _mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("versao")]
    public ActionResult<string> GetActionResultAsync()
    {
        return Ok("versao-api.3.0 - TESTE SERVIDOR PC DO PEDRO");
    }



    [AllowAnonymous]
    [HttpPost("criar-conta")]
    public async Task<ActionResult<RequestResult<UserDto>>> CadastrarUsuario([FromBody] UserCreateCommand command)
    {
        return new ReturnActionResult<UserDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<RequestResult<UsuarioLoginResponse>>> Login([FromBody] UserLoginCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("gerar-token-recuperar-senha")]
    public async Task<ActionResult<RequestResult<UserDtoSolicitarTokenResult>>> TokenRecuperacaoSenha([FromBody] SolicitarTokenRecuperacaoSenhaCommand command)
    {
        return new ReturnActionResult<UserDtoSolicitarTokenResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPut("recuperar-senha")]
    public async Task<ActionResult<RequestResult<UserDtoRecuperarSenhaResult>>> RecuperacaoSenha([FromBody] SolicitarRecuperacaoSenhaCommand command)
    {
        return new ReturnActionResult<UserDtoRecuperarSenhaResult>().ParseToActionResult(await _mediator.Send(command));
    }

    [AllowAnonymous]
    [HttpPut("alterar-senha")]
    public async Task<ActionResult<RequestResult<UserDtoUpdateSenhaResult>>> AlterarSenha([FromBody] AlterarSenhaUserCommand command)
    {
        return new ReturnActionResult<UserDtoUpdateSenhaResult>().ParseToActionResult(await _mediator.Send(command));
    }

    //[AllowAnonymous]
    //[HttpGet("GetUsers")]
    //public async Task<ActionResult<RequestResultForUpdate>> GetUsersAsync()
    //{
    //    return await _mediator.Send(new GetUsersQuery());
    //}



    //[AllowAnonymous]
    //[HttpPut("desabilitar-usuario")]
    //public async Task<ActionResult<RequestResult<UserDtoHabilitarDesabilitarRequestResult>>> DesabilitarUsuario([FromBody] DesabilitarUserCommand command)
    //{
    //    return new ReturnActionResult<UserDtoHabilitarDesabilitarRequestResult>().ParseToActionResult(await _mediator.Send(command));
    //}

    //[AllowAnonymous]
    //[HttpPut("habilitar-usuario")]
    //public async Task<ActionResult<RequestResult<UserDtoHabilitarDesabilitarRequestResult>>> HabilitarrUsuario([FromBody] HabilitarUserCommand command)
    //{
    //    return new ReturnActionResult<UserDtoHabilitarDesabilitarRequestResult>().ParseToActionResult(await _mediator.Send(command));
    //}

    //[HttpPut("update-nome-sobrenome")]
    //public async Task<ActionResult<RequestResult<UserDto>>> UpdateNomeSobreNome([FromBody] UserCommandUpdateNomeSobreNome command)
    //{
    //    return new ReturnActionResult<UserDto>().ParseToActionResult(await _mediator.Send(command));
    //}

    ////[AllowAnonymous]
    //[HttpPost("upload-image/{userId}")]
    //public async Task<ActionResult<RequestResult<UserDtoImageResult>>> UploadImage([FromServices] UserManager<UserEntity> _userManager, [FromServices] IUtil _util, Guid userId)
    //{
    //    try
    //    {
    //        if (!Request.HasFormContentType)
    //        {
    //            return RequestResult<UserDtoImageResult>.BadRequest("Arquivo não localizado");
    //        }

    //        string _destino = "Perfil";
    //        var user = await _userManager.FindByIdAsync(userId.ToString());
    //        if (user == null) return NoContent();

    //        var file = Request.Form.Files[0];
    //        if (file.Length > 0)
    //        {
    //            _util.DeleteImage(user.ImagemURL, _destino);
    //            user.AlterarUrlImage(await _util.SaveImage(file, _destino));
    //        }
    //        var userRetorno = await _userManager.UpdateAsync(user);

    //        var userAlterado = await _userManager.FindByEmailAsync(user.Email!);

    //        var result = new UserDtoImageResult(userAlterado!.Id, userAlterado.ImagemURL!, userAlterado!.Email!);

    //        return Ok(result);
    //    }
    //    catch (Exception ex)
    //    {
    //        return this.StatusCode(StatusCodes.Status500InternalServerError,
    //            $"Erro ao tentar realizar upload de Foto do Usuário. Erro: {ex.Message}");
    //    }
    //}

}