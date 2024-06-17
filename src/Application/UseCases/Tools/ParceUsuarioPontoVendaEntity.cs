using Application.UseCases.Commands.PontoVenda.Usuario;
using Domain.Entities.PontoVendaUser;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static UsuarioPontoVendaEntity ParceUsuarioPontoVendaEntity(RegistrarUsuarioPontoVendaCommand command, UserMasterUserDtoCreate users)
        {
            return UsuarioPontoVendaEntity.CreateUsuarioPontoVenda(userId: command.IdUser,
                                                                    users: users);
        }
    }
}
