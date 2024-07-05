using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class UserMasterUserCreateCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UserMasterUserCreateCommand, RequestResult>
{

    public async Task<RequestResult> Handle(UserMasterUserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userMasterUserEntity = UserMasterUserEntity.Create(request.Filtro.clienteId, request.Filtro.userId);
            if (!userMasterUserEntity.isValid)
                return new RequestResult().EntidadeInvalida();

            await _unitOfWork.UserMasterUserRepository.Cadastrar(userMasterUserEntity);
            var result = await _unitOfWork.CommitAsync();
            if (result)
                return new RequestResult().Ok("Cadastrado efetuado com sucesso!");

            return new RequestResult().BadRequest("Não foi possível realizar cadastro");
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}
