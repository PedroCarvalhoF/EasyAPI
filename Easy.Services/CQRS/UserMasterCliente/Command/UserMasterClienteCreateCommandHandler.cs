using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class UserMasterClienteCreateCommandHandler : IRequestHandler<UserMasterClienteCreateCommand, RequestResultForUpdate>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserMasterClienteCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RequestResultForUpdate> Handle(UserMasterClienteCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userMCliente = new UserMasterClienteEntity(request.UserId);
            if (!userMCliente.IsValid)
                return new RequestResultForUpdate().EntidadeInvalida();

            await _unitOfWork.UserMasterClienteRepository.CadastrarCliente(userMCliente);
            if (!await _unitOfWork.CommitAsync())
                return new RequestResultForUpdate().BadRequest("Não foi possível cadastrar cliente master.");

            return new RequestResultForUpdate().Ok("Cliente master cadastrado com sucesso!");
        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}
