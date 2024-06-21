using Easy.Domain.Entities.UserMasterUser;

namespace Easy.Domain.Intefaces.Repository.UserMasterUser;

public interface IUserMasterUserDapperRepository
{
    Task<IEnumerable<UserMasterUserEntity>> GetUsersMastersClientesAsync();
    Task<UserMasterUserEntity> GetUserMasterClienteByIdAsync(Guid id);
}
