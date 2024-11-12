using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserIdentity;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command
{
    public class UserCreateCommand : IRequest<RequestResult<UserDto>>
    {
        public required UserDtoCreate UserCreate { get; set; }
        public class UserCreateCommandHandler(UserManager<UserEntity> _userManager) : IRequestHandler<UserCreateCommand, RequestResult<UserDto>>
        {            
            public async Task<RequestResult<UserDto>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var userExists = await _userManager.FindByEmailAsync(request.UserCreate.Email);
                    if (userExists != null)
                        return RequestResult<UserDto>.BadRequest("E-mail já esta em uso");

                    var userCreateEntity = UserEntity.CreateUser(request.UserCreate.Nome, request.UserCreate.SobreNome, request.UserCreate.Email, request.UserCreate.Email);

                    var userCreateResult = await _userManager.CreateAsync(userCreateEntity, request.UserCreate.Senha);

                    var usuarioCadastroResponse = new UsuarioCadastroResponse(true, userCreateEntity.Id);
                    if (userCreateResult.Succeeded)
                    {
                        //await _userManager.SetLockoutEnabledAsync(userCreateEntity, false);

                        var userCreate = await _userManager.FindByEmailAsync(request.UserCreate.Email);                        

                        var userDto = DtoMapper.ParceUserDto(userCreateEntity);

                        return RequestResult<UserDto>.Ok(userDto);
                    }


                    if (!userCreateResult.Succeeded && userCreateResult.Errors.Count() > 0)
                        usuarioCadastroResponse.AdicionarErros(userCreateResult.Errors.Select(r => r.Description));

                    return RequestResult<UserDto>.BadRequest(userCreateResult.Errors.Select(r => r.Description).FirstOrDefault());

                }
                catch (Exception ex)
                {
                    return RequestResult<UserDto>.BadRequest(ex.Message);
                }
            }
        }

    }
}
