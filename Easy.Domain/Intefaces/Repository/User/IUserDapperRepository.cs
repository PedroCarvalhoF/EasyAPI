using Easy.Domain.Entities.User;

namespace Easy.Domain.Intefaces.Repository.User;

public interface IUserDapperRepository
{
    Task<IEnumerable<UserEntity>> GetUsers();
    Task<UserEntity> GetUserById(Guid id);
}
