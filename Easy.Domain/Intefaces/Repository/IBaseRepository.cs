using Easy.Domain.Entities;

namespace Easy.Domain.Intefaces.Repository
{
    public interface IBaseRepository<T, F> where T : BaseEntity where F : FiltroBase
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(int id);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}