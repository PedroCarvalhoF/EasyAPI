using Application.Results;
using Application.UseCases.Commands.User;

namespace Application.UseCases.Handlers.User
{
    public interface IUserHandler<T, Y> where T : UserCreateCommand where Y : UserUpdatePassword
    {
        Task<RequestResult> Cadastrar(T command);
        Task<RequestResult> AlterarSenha(Y command);

    }
}
