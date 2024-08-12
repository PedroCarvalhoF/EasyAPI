using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command;

public class DesabilitarUserCommand : BaseCommands<UserDtoHabilitarDesabilitarRequestResult>
{
    public UserDtoEmailRequest User { get; private set; }

    public DesabilitarUserCommand(UserDtoEmailRequest user)
    {
        User = user;
    }

    public class DesabilitarUserCommandHandler(UserManager<UserEntity> _userManager) : IRequestHandler<DesabilitarUserCommand, RequestResult<UserDtoHabilitarDesabilitarRequestResult>>
    {
        public async Task<RequestResult<UserDtoHabilitarDesabilitarRequestResult>> Handle(DesabilitarUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.User.Email);
                if (user == null)
                    return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.BadRequest("Usuário nao localizado");

                user.LockoutEnabled = true; // Ativa o bloqueio
                user.LockoutEnd = DateTimeOffset.MaxValue; // Define o bloqueio por tempo indefinido
                await _userManager.UpdateAsync(user); // Atualiza o usuário no banco de dados

                var dtoResult = new UserDtoHabilitarDesabilitarRequestResult(true, "Usuário desabilitado com sucesso.");

                return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.Ok(dtoResult);
            }
            catch (Exception ex)
            {

                return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.BadRequest(ex.Message);
            }
        }
    }
}
