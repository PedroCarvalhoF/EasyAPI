using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class CreateUserMasterClienteCommand : IRequest<bool>
{
    public Guid UserMasterId { get; set; }
    public class CreateUserMasterClienteCommandHandler : IRequestHandler<CreateUserMasterClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserMasterClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserMasterClienteCommand request, CancellationToken cancellationToken)
        {
            var newUserMCliente = new UserMasterClienteEntity(request.UserMasterId);
            await _unitOfWork.UsuarioMasterClienteRepository.InsertAsync(newUserMCliente);
            await _unitOfWork.CommitAsync();
            if (newUserMCliente != null) return true;

            return false;
        }
    }

}
