using Application.Results;
using Application.UseCases.Commands.UserMasterCliente;

namespace Application.UseCases.Handlers.UserMasterCliente
{
    public interface IUserMasterClienteHandler<T> where T : UserMasterCreateCommand
    {
        Task<RequestResult> CadastrarUsuarioMaster(T command);
        Task<RequestResult> GetAll();
    }
}
