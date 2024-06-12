using Api.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> SelectAsync(Guid? filtroId = null);
        Task<T> SelectAsync(Guid id, Guid? filtroId = null);
        Task<bool> ExistAsync(Guid id, Guid? filtroId = null);
        Task<T> InsertAsync(T item, Guid? filtroId = null);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> itens, Guid? filtroId = null);
        Task<int> InsertArrayAsync(IEnumerable<T> entity, Guid? filtroId = null);
        Task<T> UpdateAsync(T item, Guid? filtroId = null);
        Task<bool> DesabilitarHabilitar(Guid id, Guid? filtroId = null);
        Task<bool> DeleteAsync(Guid id, Guid? filtroId = null);
        Task<int> DeleteAsync(IEnumerable<Guid> ids, Guid? filtroId = null);
        Task<int> DeleteAsync(IEnumerable<T> itens, Guid? filtroId = null);
    }
}
