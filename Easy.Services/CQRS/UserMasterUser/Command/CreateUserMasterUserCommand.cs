using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
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

    public class CreateUserMasterUserCommandHandler : IRequestHandler<CreateUserMasterUserCommand, RequestResult>
    {
        private readonly IUnitOfWork _repository;

        public CreateUserMasterUserCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult> Handle(CreateUserMasterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = UserMasterUserEntity.Create(request.UserClienteId, request.UserMasterUserId);
                if (!entity.isValid) return new RequestResult().EntidadeInvalida();

                await _repository.UserMasterUserRepository.InsertAsync(entity);
                var result = await _repository.CommitAsync();

                if (result)
                    return new RequestResult().Ok("Liberado acesso ao usuário.");

                return new RequestResult().BadRequest("Não foi possível credenciar usuário");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadCreate(ex.Message);
            }
        }
    }
}
