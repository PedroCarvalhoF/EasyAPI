using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;

namespace Easy.Services.Intefaces.User
{
    internal interface IUserService
    {
        Task<RequestResult> GetUsers();
        Task<RequestResult> GetUserById(Guid id);
        Task<RequestResult> GetUserByEmail(string email);
        Task<RequestResult> Create(UsuarioCadastroRequest usuarioCadastro);
        Task<RequestResult> AlterarSenha(UsuarioUpdateSenhaRequest usuarioUpdateSenha);
        Task<RequestResult> Login(UsuarioLoginRequest usuarioLogin);
    }
}
