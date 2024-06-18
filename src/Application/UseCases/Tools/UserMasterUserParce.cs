using Application.UseCases.Commands.UserMasterUser;
using Domain.Entities.UserMasterUser;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static UserMasterUserEntity ParceUserMasterUserEntity(UserMasterUserCreateCommand command)
        {
            return UserMasterUserEntity.Create(command.UserClienteId, command.UserMasterUserId);

        }
    }
}
