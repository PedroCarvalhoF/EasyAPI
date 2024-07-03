using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using Easy.Services.Service;
using MediatR;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, RequestResult>
{
    private readonly IUserService _userService;

    public UserLoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RequestResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userRequest = new UsuarioLoginRequest
            {
                Email = request.Email,
                Senha = request.Senha
            };

            var resultUser = await _userService.Login(userRequest);
            if (resultUser.sucesso)
                return new RequestResult().Ok(resultUser);

            return new RequestResult().BadRequest(resultUser);
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}