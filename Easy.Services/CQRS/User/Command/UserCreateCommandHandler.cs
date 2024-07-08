using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, RequestResult<UsuarioCadastroResponse>>
{
    private readonly UserManager<UserEntity> _userManager;

    public UserCreateCommandHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RequestResult<UsuarioCadastroResponse>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                return RequestResult<UsuarioCadastroResponse>.BadRequest("E-mail já esta em uso.");

            var userCreateEntity = UserEntity.CreateUser(request.Nome, request.SobreNome, request.Email, request.Email);

            var userCreateResult = await _userManager.CreateAsync(userCreateEntity, request.Senha);

            var usuarioCadastroResponse = new UsuarioCadastroResponse(true, userCreateEntity.Id);
            if (userCreateResult.Succeeded)
            {                
                await _userManager.SetLockoutEnabledAsync(userCreateEntity, false);
                return RequestResult<UsuarioCadastroResponse>.Ok(usuarioCadastroResponse, "Usuário criado com sucesso.");
            }


            if (!userCreateResult.Succeeded && userCreateResult.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(userCreateResult.Errors.Select(r => r.Description));

            return RequestResult<UsuarioCadastroResponse>.BadRequest(userCreateResult.Errors.Select(r => r.Description).FirstOrDefault());

        }
        catch (Exception ex)
        {
            return RequestResult<UsuarioCadastroResponse>.BadRequest(ex.Message);
        }
    }
}
