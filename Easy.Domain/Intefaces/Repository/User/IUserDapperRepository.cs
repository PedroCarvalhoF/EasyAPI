using Easy.Domain.Entities.User;

namespace Easy.Domain.Intefaces.Repository.User;

public interface IUserDapperRepository
{
    Task<IEnumerable<UserEntity>> GetUsersAsync();
    Task<UserEntity> GetUserByIdAsync(Guid id);
    Task<UserEntity> GetUserByEmailAsync(string email);
}
