using Application.Interfaces.Repository;
using Application.Results;
using Application.UseCases.Commands.UserMasterUser;
using Application.UseCases.Tools;
using Domain.Entities.UserMasterUser;

namespace Application.UseCases.Handlers.UserMasterUser
{
    public class UserMasterUserHadler : IUserMasterUserHadler<UserMasterUserCreateCommand>
    {
        private readonly IRepositoryGeneric<UserMasterUserEntity> _repository;
        public UserMasterUserHadler(IRepositoryGeneric<UserMasterUserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult> CadastrarUsuarioCliente(UserMasterUserCreateCommand userMasterUser)
        {
            try
            {
                var entity = EntityMapper.ParceUserMasterUserEntity(command: userMasterUser); ;
                if (!entity.isValid)
                    return new RequestResult().EntidadeInvalida();

                var resultCreateEntity = await _repository.InsertGenericAsync(entity);
                if (resultCreateEntity == null)
                    return new RequestResult().BadRequest("Não foi possível cadastrar usuário oa cliente");

                return new RequestResult().Ok("Liberado acesso ao usuário.");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
