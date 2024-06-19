using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class CreateUserMasterUserCommandHandler : IRequestHandler<CreateUserMasterUserCommand, RequestResult>
{
    private readonly IRepositoryGeneric<UserMasterUserEntity> _repository;

    public CreateUserMasterUserCommandHandler(IRepositoryGeneric<UserMasterUserEntity> repository)
    {
        _repository = repository;
    }

    public async Task<RequestResult> Handle(CreateUserMasterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = UserMasterUserEntity.Create(request.UserClienteId, request.UserMasterUserId);
            if (!entity.isValid) return new RequestResult().EntidadeInvalida();
           
            var resultCreateEntity = await _repository.InsertGenericAsync(entity);
            if (resultCreateEntity == null)
                return new RequestResult().BadRequest("Não foi possível cadastrar usuário oa cliente");

            return new RequestResult().Ok("Liberado acesso ao usuário.");

        }
        catch (Exception ex)
        {

            return new RequestResult().BadCreate(ex.Message);
        }
    }
}
