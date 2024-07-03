using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, RequestResult>
{
    private readonly UserManager<UserEntity> _userManager;

    public UserCreateCommandHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RequestResult> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                return new RequestResult().BadRequest("E-mail já esta em uso");

            var userCreateEntity = UserEntity.CreateUser(request.Nome, request.SobreNome, request.Email, request.Email);

            var userCreateResult = await _userManager.CreateAsync(userCreateEntity, request.Senha);
            if (userCreateResult.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(userCreateEntity, false);
                return new RequestResult().Ok("Usuário criado com sucesso");
            }

            var usuarioCadastroResponse = new UsuarioCadastroResponse();
            if (!userCreateResult.Succeeded && userCreateResult.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(userCreateResult.Errors.Select(r => r.Description));

            return new RequestResult().BadRequest(usuarioCadastroResponse);

        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}
