using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class UserMasterClienteCreateCommand : IRequest<RequestResult>
{
    public Guid UserId { get; set; }
}
