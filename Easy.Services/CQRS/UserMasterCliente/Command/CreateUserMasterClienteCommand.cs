using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class CreateUserMasterClienteCommand : IRequest<RequestResult>
{
    public Guid UserMasterId { get; set; }
    public class CreateUserMasterClienteCommandHandler : IRequestHandler<CreateUserMasterClienteCommand, RequestResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserMasterClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult> Handle(CreateUserMasterClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUserMCliente = new UserMasterClienteEntity(request.UserMasterId);
                await _unitOfWork.UserMasterClienteRepository.AddMemberAsync(newUserMCliente);
                var commit = await _unitOfWork.CommitAsync();

                if (commit)
                    return new RequestResult().Ok();

                return new RequestResult().BadRequest();
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
