using Application.Results;
using Application.UseCases.Commands.UserMasterUser;

namespace Application.UseCases.Handlers.UserMasterUser
{
    public interface IUserMasterUserHadler<T> where T : UserMasterUserCreateCommand
    {
         Task<RequestResult> CadastrarUsuarioCliente(T userMasterUser);
    }
}
