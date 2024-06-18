using Domain.Entities.UserMasterCliente;

namespace Application.Interfaces.Repository
{
    public interface IUsuarioMasterClienteRepository<T> where T : UserMasterClienteEntity
    {
        Task<T> InsertAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>? GetByIdAsync(Guid id);
        Task<bool> Exists(Guid id);

    }
}
