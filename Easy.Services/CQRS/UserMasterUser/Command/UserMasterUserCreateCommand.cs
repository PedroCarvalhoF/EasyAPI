using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserMasterUser;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class UserMasterUserCreateCommand : BaseCommands<string>
{
    public required UserMasterUserDtoCreate UserMasterUser { get; set; }
    public class UserMasterUserCreateCommandHandler(IUnitOfWork _unitOfWork, UserManager<UserEntity> _userManager) : IRequestHandler<UserMasterUserCreateCommand, RequestResult<string>>
    {
        public async Task<RequestResult<string>> Handle(UserMasterUserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var usuario = await _userManager.FindByEmailAsync(request.UserMasterUser.Email) ?? new UserEntity();
                if (usuario.Id == Guid.Empty)
                    return RequestResult<string>.BadRequest("Usúario não localizado.");

                var userMasterUserEntity = UserMasterUserEntity.Create(request.GetFiltro().clienteId, usuario.Id);
                if (!userMasterUserEntity.isValid)
                    return RequestResult<string>.BadRequest("Entidade Invalida.");


                var userMasterUserExists = await _unitOfWork.UserMasterUserRepository.GetById(usuario.Id);
                if (userMasterUserExists != null)
                {

                    var cliente = await _userManager.FindByIdAsync(userMasterUserExists.UserClienteId.ToString());

                    return RequestResult<string>.BadRequest($"Usuário já esta crendeciado para: {cliente!.Nome} - {cliente.Email} ");
                }


                await _unitOfWork.UserMasterUserRepository.Cadastrar(userMasterUserEntity);
                var result = await _unitOfWork.CommitAsync();
                if (result)
                    return RequestResult<string>.Ok(mensagem: "Usuário crendenciado com sucesso.");

                return RequestResult<string>.BadRequest(mensagem: "Erro o credenciar usuário.");
            }
            catch (Exception ex)
            {

                return RequestResult<string>.BadRequest(mensagem: ex.Message);
            }
        }
    }

}
