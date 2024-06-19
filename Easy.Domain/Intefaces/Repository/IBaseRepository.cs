using Easy.Domain.Entities;

namespace Easy.Domain.Intefaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);                
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);        
    }
}