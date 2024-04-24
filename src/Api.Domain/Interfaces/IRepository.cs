using Api.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> itens);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<int> DeleteAsync(IEnumerable<Guid> ids);

        Task<bool> DesabilitarHabilitar(Guid id);
    }
}
