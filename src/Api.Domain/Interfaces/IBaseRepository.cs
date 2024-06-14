using Api.Domain.Entities;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items, UserMasterUserDtoCreate? user = null);
        Task<int> InsertArrayAsync(IEnumerable<T> entity, UserMasterUserDtoCreate? user = null);
        Task<T> UpdateAsync(T item, UserMasterUserDtoCreate? user = null);
        Task<bool> DeleteAsync(Guid id, UserMasterUserDtoCreate? user = null);
        Task<int> DeleteAsync(IEnumerable<Guid> ids, UserMasterUserDtoCreate? user = null);
        Task<int> DeleteAsync(IEnumerable<T> items, UserMasterUserDtoCreate? user = null);
        Task<T> SelectAsync(Guid id, UserMasterUserDtoCreate? user = null);
        Task<IEnumerable<T>> SelectAsync(UserMasterUserDtoCreate? user = null);
        Task<bool> ExistAsync(Guid id, UserMasterUserDtoCreate? user = null);
        Task<bool> DesabilitarHabilitar(Guid id, UserMasterUserDtoCreate? user = null);
    }
}
