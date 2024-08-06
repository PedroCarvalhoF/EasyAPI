using Easy.Domain.Entities;
using Easy.Domain.Entities.User;

namespace Easy.Domain.Intefaces.Repository.UserMasterUser;

public interface IUserMasterUserDapperRepository<F> where F : FiltroBase
{
    Task<IEnumerable<UserEntity>> GetUsersMasterUsersAsync(F filtro);
    Task<UserEntity> GetUserByIdUser(Guid userId, F filtro);
}
