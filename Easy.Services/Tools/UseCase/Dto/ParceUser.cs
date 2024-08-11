using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.User;
using Easy.Services.DTOs.User;

namespace Easy.Services.Tools.UseCase.Dto;
public partial class DtoMapper
{
    public static UserDto ParceUserDto(UserEntity user)
    {
        return new UserDto
        {
            Email = user.Email,
            Id = user.Id,
            Nome = user.Nome,
            SobreNome = user.SobreNome
        };
    }

    public static IEnumerable<UserDto> ParceUsersDtos(IEnumerable<UserEntity> users)
    {
        foreach (var user in users)
        {
            yield return ParceUserDto(user);
        }
    }

    public static IEnumerable<UserDto> ParceUsersDtos(IEnumerable<UsuarioPdvEntity> usersPdvs)
    {
        foreach (var user in usersPdvs)
        {
            yield return ParceUserDto(user.UserPdv);
        }
    }
}
