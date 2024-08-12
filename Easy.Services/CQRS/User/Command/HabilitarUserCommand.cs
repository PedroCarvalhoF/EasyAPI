using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command;

public class HabilitarUserCommand : BaseCommands<UserDtoHabilitarDesabilitarRequestResult>
{
    public UserDtoEmailRequest User { get; private set; }

    public HabilitarUserCommand(UserDtoEmailRequest user)
    {
        User = user;
    }

    public class HabilitarUserCommandHandler(UserManager<UserEntity> _userManager) : IRequestHandler<HabilitarUserCommand, RequestResult<UserDtoHabilitarDesabilitarRequestResult>>
    {
        public async Task<RequestResult<UserDtoHabilitarDesabilitarRequestResult>> Handle(HabilitarUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.User.Email);
                if (user != null)
                {
                    user.LockoutEnabled = false;
                    user.LockoutEnd = null; 
                    await _userManager.UpdateAsync(user); 

                    var result = new UserDtoHabilitarDesabilitarRequestResult(true, "Usuário habilitado novamente.");

                    return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.Ok(result);
                }

                return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.BadRequest("Usuário não localizado");
            }
            catch (Exception ex)
            {

                return RequestResult<UserDtoHabilitarDesabilitarRequestResult>.BadRequest(ex.Message);
            }
        }
    }
}
