namespace Application.UseCases.Commands.UserMasterUser
{
    public class UserMasterUserCreateCommand : ICommand
    {
        public UserMasterUserCreateCommand(Guid userClienteId, Guid userMasterUserId)
        {
            UserClienteId = userClienteId;
            UserMasterUserId = userMasterUserId;
        }

        public Guid UserClienteId { get; private set; }
        public Guid UserMasterUserId { get; private set; }

    }
}
