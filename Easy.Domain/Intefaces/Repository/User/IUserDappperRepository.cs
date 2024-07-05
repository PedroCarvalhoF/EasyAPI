using Easy.Domain.Entities.User;

namespace Easy.Domain.Intefaces.Repository.User;

public interface IUserDappperRepository
{
    Task<IEnumerable<UserEntity>> GetUsersAscyn();
}
