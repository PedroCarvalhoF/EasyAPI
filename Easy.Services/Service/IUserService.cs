using Easy.Services.DTOs.UserIdentity;

namespace Easy.Services.Service;

public interface IUserService
{
    Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
    Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
}
