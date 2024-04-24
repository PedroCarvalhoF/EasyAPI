using Api.Domain.Dtos.IdentityDto;
using Domain.Dtos.IdentityDto;

namespace Api.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
        Task<UsuarioDto> GetUserById(Guid id);
        Task<IEnumerable<UsuarioDto>> GetAll();
    }
}
