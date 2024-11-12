using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using Easy.Services.Service;
using MediatR;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommand : IRequest<RequestResult<UsuarioLoginResponse>>
{
    public required UsuarioLoginRequest UsuarioLoginRequest { get;set;}
    public class UserLoginCommandHandler(IUserService _userService) : IRequestHandler<UserLoginCommand, RequestResult<UsuarioLoginResponse>>
    {        
        public async Task<RequestResult<UsuarioLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {            
            var resultUser = await _userService.Login(request.UsuarioLoginRequest);
            return resultUser;
        }
    }
}
