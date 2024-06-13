using Api.Domain.Entities;
using Domain.UserIdentity.MasterUsers;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item, UserMasterUserEntity user);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items, UserMasterUserEntity user);
        Task<int> InsertArrayAsync(IEnumerable<T> entity, UserMasterUserEntity user);
        Task<T> UpdateAsync(T item, UserMasterUserEntity user);
        Task<bool> DeleteAsync(Guid id, UserMasterUserEntity user);
        Task<int> DeleteAsync(IEnumerable<Guid> ids, UserMasterUserEntity user);
        Task<int> DeleteAsync(IEnumerable<T> items, UserMasterUserEntity user);
        Task<T> SelectAsync(Guid id, UserMasterUserEntity user);
        Task<IEnumerable<T>> SelectAsync(UserMasterUserEntity user);
        Task<bool> ExistAsync(Guid id, UserMasterUserEntity user);
        Task<bool> DesabilitarHabilitar(Guid id, UserMasterUserEntity user);
    }
}
