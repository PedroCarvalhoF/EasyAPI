using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class CreateUserMasterUserCommand : IRequest<RequestResult>
{
    public CreateUserMasterUserCommand(Guid userClienteId, Guid userMasterUserId)
    {
        UserClienteId = userClienteId;
        UserMasterUserId = userMasterUserId;
    }

    public Guid UserClienteId { get; private set; }
    public Guid UserMasterUserId { get; private set; }
}
