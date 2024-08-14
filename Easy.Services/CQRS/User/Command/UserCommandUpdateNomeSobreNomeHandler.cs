using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.User.Command
{
    public class UserCommandUpdateNomeSobreNomeHandler(UserManager<UserEntity> _userManager) : IRequestHandler<UserCommandUpdateNomeSobreNome, RequestResult<UserDto>>
    {
        public async Task<RequestResult<UserDto>> Handle(UserCommandUpdateNomeSobreNome request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.UserDtoUpdate.Email);
                if (user != null)
                {
                    user.AlterarNomeSobreNome(request.UserDtoUpdate.Nome, request.UserDtoUpdate.SobreNome);

                    await _userManager.UpdateAsync(user);


                    var userUpdate = await _userManager.FindByEmailAsync(user.Email!);

                    var dto = DtoMapper.ParceUserDto(userUpdate!);

                    return RequestResult<UserDto>.Ok(dto);
                }

                return RequestResult<UserDto>.BadRequest();

            }
            catch (Exception ex)
            {

                return RequestResult<UserDto>.BadRequest(ex.Message);
            }
        }
    }
}
