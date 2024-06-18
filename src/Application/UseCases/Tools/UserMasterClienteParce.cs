using Application.UseCases.Commands.UserMasterCliente;
using Domain.Entities.UserMasterCliente;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static UserMasterClienteEntity UserMasterCliente(UserMasterCreateCommand command)
        {
            return UserMasterClienteEntity
                .Create(userMasterId: command.UserMasterId);
        }
    }
}
