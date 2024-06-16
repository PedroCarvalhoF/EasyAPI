using Domain.UserIdentity.Masters;

namespace Domain.Interfaces
{
    public interface IRequiredRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(UserMasterUserDtoCreate user);
        Task<T> Get(Guid id, UserMasterUserDtoCreate user);
        Task<bool> Exists(string name, UserMasterUserDtoCreate user);
    }
}
