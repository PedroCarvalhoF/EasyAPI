using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.User.Command;

public class AlterarSenhaUserCommandHandler : IRequestHandler<AlterarSenhaUserCommand, RequestResult>
{
    public Task<RequestResult> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
