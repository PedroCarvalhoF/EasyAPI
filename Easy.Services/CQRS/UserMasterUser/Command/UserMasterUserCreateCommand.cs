using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class UserMasterUserCreateCommand : BaseCommands<string>
{
    public Guid UsuarioId { get; set; }
    public class UserMasterUserCreateCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UserMasterUserCreateCommand, RequestResult<string>>
    {

        public async Task<RequestResult<string>> Handle(UserMasterUserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userMasterUserEntity = UserMasterUserEntity.Create(request.GetFiltro().clienteId, request.UsuarioId);
                if (!userMasterUserEntity.isValid)
                    return RequestResult<string>.BadRequest("Entidade Invalida");

                await _unitOfWork.UserMasterUserRepository.Cadastrar(userMasterUserEntity);
                var result = await _unitOfWork.CommitAsync();
                if (result)
                    return RequestResult<string>.Ok(null, mensagem: "Cadastrado efetuado com sucesso");

                return RequestResult<string>.BadRequest(mensagem: "Erro o credenciar usuário  ");
            }
            catch (Exception ex)
            {

                return RequestResult<string>.BadRequest(mensagem: ex.Message);
            }
        }
    }

}
