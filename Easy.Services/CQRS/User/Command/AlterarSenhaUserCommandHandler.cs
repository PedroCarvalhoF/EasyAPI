using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.User.Command;

public class AlterarSenhaUserCommandHandler : IRequestHandler<AlterarSenhaUserCommand, RequestResultForUpdate>
{
    public Task<RequestResultForUpdate> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
