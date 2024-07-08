using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class UserMasterClienteCreateCommand : IRequest<RequestResultForUpdate>
{
    public Guid UserId { get; set; }
}
