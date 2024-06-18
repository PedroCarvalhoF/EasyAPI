using Easy.Domain.Entities.UserMasterCliente;

namespace Easy.Domain.Intefaces.Repository.UsuarioMasterCliente
{
    public interface IUsuarioMasterClienteRepository<T> where T : UserMasterClienteEntity
    {
        Task<T> InsertAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>? GetByIdAsync(Guid id);
        Task<bool> Exists(Guid id);

    }
}
