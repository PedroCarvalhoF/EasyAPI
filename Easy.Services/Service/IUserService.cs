using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;

namespace Easy.Services.Service;

public interface IUserService
{
    Task<RequestResult<UsuarioCadastroResponse>> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
    Task<RequestResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin);
}
