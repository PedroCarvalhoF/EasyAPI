using Easy.Domain.Entities.UserMasterCliente;

namespace Easy.Domain.Intefaces.Repository.UsuarioMasterCliente
{
    public interface IUsuarioMasterClienteRepository
    {
        Task<IEnumerable<UserMasterClienteEntity>> GetAllAsync();
        Task<UserMasterClienteEntity> GetByIdAsync(Guid id);
        Task<UserMasterClienteEntity> InsertAsync(UserMasterClienteEntity item);

    }
}
