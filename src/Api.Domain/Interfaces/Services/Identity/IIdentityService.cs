using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity;

namespace Api.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<User> GetUserById(Guid id);
        Task<Guid> GetIdIdentityByName(string name);
        Task<ResponseDto<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro);

    }
}
