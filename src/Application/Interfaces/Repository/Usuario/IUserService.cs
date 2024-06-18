using Application.Results;
using Domain.UserIdentity;

namespace Application.Interfaces.Repository.Usuario
{
    internal interface IUserService
    {
        Task<RequestResult> GetAll();
        Task<RequestResult> GetUserById(Guid id);
        Task<RequestResult> GetUserByEmail(string email);        
        Task<RequestResult> Create(UsuarioCadastroRequest usuarioCadastro);
        Task<RequestResult> AlterarSenha(UsuarioUpdateSenhaRequest usuarioUpdateSenha);
        Task<RequestResult> Login(UsuarioLoginRequest usuarioLogin);
    }
}
