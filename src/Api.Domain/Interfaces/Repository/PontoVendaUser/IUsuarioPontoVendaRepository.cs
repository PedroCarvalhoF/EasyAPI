using Domain.Entities.PontoVendaUser;

namespace Domain.Interfaces.Repository.PontoVendaUser
{
    public interface IUsuarioPontoVendaRepository
    {
        Task<IEnumerable<UsuarioPontoVendaEntity>> GetAll();
        Task<UsuarioPontoVendaEntity> Get(Guid id);
        Task<UsuarioPontoVendaEntity> GetByIdUser(Guid userId);
    }
}
