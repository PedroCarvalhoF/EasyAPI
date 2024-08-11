using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command
{
    public class AlterarSenhaUserCommand : BaseCommands<UserDtoUpdateSenhaResult>
    {
        public UserDtoUpdateSenha UserDtoUpdateSenha { get; private set; }

        public AlterarSenhaUserCommand(UserDtoUpdateSenha userDtoUpdateSenha)
        {
            UserDtoUpdateSenha = userDtoUpdateSenha;
        }

        public class AlterarSenhaUserCommandHandler(UserManager<UserEntity> _userManager) : IRequestHandler<AlterarSenhaUserCommand, RequestResult<UserDtoUpdateSenhaResult>>
        {
            public async Task<RequestResult<UserDtoUpdateSenhaResult>> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(request.UserDtoUpdateSenha.email);
                    if (user == null)
                        return RequestResult<UserDtoUpdateSenhaResult>.BadRequest("Usuário não localizado.");
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
