using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using Easy.Services.Service;
using MediatR;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, RequestResult<UsuarioLoginResponse>>
{
    private readonly IUserService _userService;
    public UserLoginCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<RequestResult<UsuarioLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var userRequest = new UsuarioLoginRequest
        {
            Email = request.Email,
            Senha = request.Senha
        };

        var resultUser = await _userService.Login(userRequest);
        return resultUser;
    }
}