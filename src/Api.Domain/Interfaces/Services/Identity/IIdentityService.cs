using Api.Domain.Dtos.IdentityDto;
using Domain.Dtos;
using Domain.Dtos.IdentityDto;

namespace Api.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<UsuarioDto> GetUserById(Guid id);
        Task<Guid> GetIdIdentityByName(string name);
        Task<ResponseDto<List<UsuarioLoginResponse>>> Login(UsuarioLoginRequest usuarioLogin);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> Create(UsuarioCadastroRequest usuarioCadastro);
        
    }
}
