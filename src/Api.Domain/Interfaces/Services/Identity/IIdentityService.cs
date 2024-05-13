using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity;

namespace Api.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<ResponseDto<List<User>>> GetAll();
        Task<User> GetUserById(Guid id);
        Task<ResponseDto<List<User>>> GetByIdRole(Guid idRole);
        Task<Guid> GetIdIdentityByName(string name);
        Task<ResponseDto<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro);
       
    }
}
