using Domain.Dtos;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity;

namespace Api.Domain.Interfaces.Services.Identity
{
    public interface IUserService
    {
        Task<ResponseDto<List<User>>> GetAll();
        Task<ResponseDto<List<User>>> GetUserById(Guid id);
        Task<ResponseDto<List<User>>> GetByIdRole(Guid idRole);
        Task<ResponseDto<List<Guid>>> GetIdIdentityByName(string name);
        Task<ResponseDto<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> AlterarSenha(UsuarioUpdateSenhaRequest usuarioUpdateSenha);
    }
}
