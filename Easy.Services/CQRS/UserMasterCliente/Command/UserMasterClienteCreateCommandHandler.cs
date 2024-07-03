using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class UserMasterClienteCreateCommandHandler : IRequestHandler<UserMasterClienteCreateCommand, RequestResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserMasterClienteCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RequestResult> Handle(UserMasterClienteCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userMCliente = new UserMasterClienteEntity(request.UserId);
            if (!userMCliente.IsValid)
                return new RequestResult().EntidadeInvalida();

            await _unitOfWork.UserMasterClienteRepository.CadastrarCliente(userMCliente);
            if (!await _unitOfWork.CommitAsync())
                return new RequestResult().BadRequest("Não foi possível cadastrar cliente master.");

            return new RequestResult().Ok("Cliente master cadastrado com sucesso!");
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}
