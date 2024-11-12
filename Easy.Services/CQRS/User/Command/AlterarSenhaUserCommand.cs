using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Service;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command
{
    public class AlterarSenhaUserCommand : BaseCommands<UserDtoUpdateSenhaResult>
    {
        public required UserDtoUpdateSenha UserDtoUpdateSenha { get;  set; }
       
        public class AlterarSenhaUserCommandHandler(UserManager<UserEntity> _userManager, IUserService _userService) : IRequestHandler<AlterarSenhaUserCommand, RequestResult<UserDtoUpdateSenhaResult>>
        {
            public async Task<RequestResult<UserDtoUpdateSenhaResult>> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(request.UserDtoUpdateSenha.email);
                    if (user == null)
                        return RequestResult<UserDtoUpdateSenhaResult>.BadRequest("Usuário não localizado.");

                    var userLogin = await _userService.Login(new DTOs.UserIdentity.UsuarioLoginRequest(request.UserDtoUpdateSenha.email, request.UserDtoUpdateSenha.SenhaAntiga));

                    if (!userLogin.Status)
                        return RequestResult<UserDtoUpdateSenhaResult>.BadRequest("Autentificação com a senha antiga falhou.");


                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resultUpdatePassword = await _userManager.ResetPasswordAsync(user, token, request.UserDtoUpdateSenha.NovaSenha);

                    if (resultUpdatePassword.Succeeded)
                        return RequestResult<UserDtoUpdateSenhaResult>.Ok(mensagem: "Senha alterada com sucesso.");

                    return RequestResult<UserDtoUpdateSenhaResult>.BadRequest(resultUpdatePassword.Errors.FirstOrDefault()!.Description);

                }
                catch (Exception ex)
                {

                    return RequestResult<UserDtoUpdateSenhaResult>.BadRequest(ex.Message);
                }
            }
        }
    }
}
