using Domain.UserIdentity.Masters;

namespace Domain.Interfaces
{
    public interface IRequiredRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(UserMasterUserDtoCreate users);
        Task<T> GetById(Guid id, UserMasterUserDtoCreate users);
        Task<bool> Exists(T entity, UserMasterUserDtoCreate users);
    }
}
