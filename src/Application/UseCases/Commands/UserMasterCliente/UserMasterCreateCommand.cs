namespace Application.UseCases.Commands.UserMasterCliente
{
    public class UserMasterCreateCommand : ICommand
    {
        public Guid UserMasterId { get; private set; }

        public UserMasterCreateCommand(Guid userMasterId)
        {
            UserMasterId = userMasterId;
        }
    }
}
