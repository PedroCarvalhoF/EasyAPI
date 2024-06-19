using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.User.Notification;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.User.Command
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, RequestResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<RequestResult> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.UserManager.FindByEmailAsync(request.Email!);
            if (exists != null)
                return new RequestResult().BadRequest("E-mail já está em uso");

            var entity = UserEntity.CreateUser(request.Nome, request.SobreNome, request.Email, request.Email);

            var userCreateResult = await _unitOfWork.UserManager.CreateAsync(entity, request.Senha);

            if (userCreateResult.Succeeded)
            {
                var userCreate = await _unitOfWork.UserManager.SetLockoutEnabledAsync(entity, false);
                await _mediator.Publish(new UserCreateNotification(entity));
                return new RequestResult().Ok("Usuário criado com sucesso.");
            }

            return new RequestResult().BadRequest(userCreateResult.Errors.Select(r => r.Description).First());
        }
    }
}
