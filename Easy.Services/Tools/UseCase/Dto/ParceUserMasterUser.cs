using Easy.Domain.Entities.UserMasterUser;
using Easy.Services.DTOs.User;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static UserDto ParceUserMasterUserDto(UserMasterUserEntity userEntity)
        {
            return
                new UserDto
                {
                    Id = userEntity.UserMasterUser.Id,
                    Email = userEntity.UserMasterUser.Email,
                    Nome = userEntity.UserMasterUser.Nome,
                    SobreNome = userEntity.UserMasterUser.SobreNome
                };
        }
    }
}
