using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.User.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.UserManager.FindByEmailAsync(request.Email!);
            if (exists != null)
                return new RequestResult().BadRequest("E-mail já está em uso");

            var entity = UserEntity.CreateUser(request.Nome, request.SobreNome, request.Email, request.Email);

            var userCreateResult = await _unitOfWork.UserManager.CreateAsync(entity, request.Senha);

            if (userCreateResult.Succeeded)
            {
                var userCreate = await _unitOfWork.UserManager.SetLockoutEnabledAsync(entity, false);
                return new RequestResult().Ok("Usuário criado com sucesso.");
            }

            return new RequestResult().BadRequest(userCreateResult.Errors.Select(r => r.Description).First());
        }
    }
}
