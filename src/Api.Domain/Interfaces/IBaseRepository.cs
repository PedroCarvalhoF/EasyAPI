using Api.Domain.Entities;
using Domain.UserIdentity.MasterUsers;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item, UserMasterUserEntity? user = null);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items, UserMasterUserEntity? user = null);
        Task<int> InsertArrayAsync(IEnumerable<T> entity, UserMasterUserEntity? user = null);
        Task<T> UpdateAsync(T item, UserMasterUserEntity? user = null);
        Task<bool> DeleteAsync(Guid id, UserMasterUserEntity? user = null);
        Task<int> DeleteAsync(IEnumerable<Guid> ids, UserMasterUserEntity? user = null);
        Task<int> DeleteAsync(IEnumerable<T> items, UserMasterUserEntity? user = null);
        Task<T> SelectAsync(Guid id, UserMasterUserEntity? user = null);
        Task<IEnumerable<T>> SelectAsync(UserMasterUserEntity? user = null);
        Task<bool> ExistAsync(Guid id, UserMasterUserEntity? user = null);
        Task<bool> DesabilitarHabilitar(Guid id, UserMasterUserEntity? user = null);
    }
}
