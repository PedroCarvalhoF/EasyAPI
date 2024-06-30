using Easy.Domain.Entities;

namespace Easy.Domain.Intefaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> SelectAsync(FiltroBase filtro);
        Task<T> SelectAsync(Guid id, FiltroBase filtro);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item, FiltroBase filtro);
    }
}