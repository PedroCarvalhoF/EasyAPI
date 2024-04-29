using Domain.Entities.UsuarioSistema;

namespace Domain.Interfaces.Repository.PerfilUsuario
{
    public interface IPerfilUsuarioRepository
    {
        Task<IEnumerable<PerfilUsuarioEntity>> GetAll();
        Task<PerfilUsuarioEntity> GetPerfilUsuarioId(Guid id);
        Task<IEnumerable<PerfilUsuarioEntity>> GetPerfilUsuarioName(string name);
    }
}
