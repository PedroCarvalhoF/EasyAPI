using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Services.DTOs.UsuarioPdv;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static UsuarioPdvDto ParceUsuarioPdvDto(UsuarioPdvEntity user)
        {
            return
               new UsuarioPdvDto(user.UserId, user.UserPdv.Nome, user.UserPdv.Email, user.Habilitado);
        }
    }
}
