using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserMaster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.UserMasterCliente.Command;

public class UserMasterClienteCreateCommand : IRequest<RequestResultForUpdate>
{
    public required UserMasterClienteDtoCreate UserCreateDto { get; set; }
    public class UserMasterClienteCreateCommandHandler : IRequestHandler<UserMasterClienteCreateCommand, RequestResultForUpdate>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserEntity> _userManager;
        public UserMasterClienteCreateCommandHandler(IUnitOfWork unitOfWork, UserManager<UserEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<RequestResultForUpdate> Handle(UserMasterClienteCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var userCreate = await _userManager.FindByEmailAsync(request.UserCreateDto.Email);
                if (userCreate is null)
                    return new RequestResultForUpdate().BadRequest("Usuário não localizado");

                var userClienteExists = await _unitOfWork.UserMasterClienteRepository.GetById(userCreate.Id);
                if (userClienteExists != null)
                    return new RequestResultForUpdate().BadRequest("Usuário já é cliente");


                var userMCliente = new UserMasterClienteEntity(userCreate.Id);
                if (!userMCliente.IsValid)
                    return new RequestResultForUpdate().EntidadeInvalida();

                await _unitOfWork.UserMasterClienteRepository.CadastrarCliente(userMCliente);

                var userMaster = new UserMasterUserEntity(userCreate.Id, userCreate.Id);
                var userMasterClienteUserCreate = await _unitOfWork.UserMasterUserRepository.Cadastrar(userMaster);


                if (!await _unitOfWork.CommitAsync())
                    return new RequestResultForUpdate().BadRequest("Não foi possível cadastrar cliente master.");

                _unitOfWork.FinalizarContexto();

                return new RequestResultForUpdate().Ok("Cliente master cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}
