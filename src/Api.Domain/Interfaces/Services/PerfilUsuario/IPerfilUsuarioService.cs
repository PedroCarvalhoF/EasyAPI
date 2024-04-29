using Domain.Dtos;
using Domain.Dtos.PerfilUsuario;

namespace Domain.Interfaces.Services.PerfilUsuario
{
    public interface IPerfilUsuarioService
    {
        Task<ResponseDto<List<PerfilUsuarioDto>>> GetAll();
        Task<ResponseDto<List<PerfilUsuarioDto>>> GetPerfilUsuarioId(Guid id);
        Task<ResponseDto<List<PerfilUsuarioDto>>> GetPerfilUsuarioName(string name);
        Task<ResponseDto<List<PerfilUsuarioDto>>> Create(PerfilUsuarioDtoCreate create);
        Task<ResponseDto<List<PerfilUsuarioDto>>> Update(PerfilUsuarioDtoUpdate update);
        Task<ResponseDto<List<PerfilUsuarioDto>>> Desabilitar(Guid id);
    }
}
