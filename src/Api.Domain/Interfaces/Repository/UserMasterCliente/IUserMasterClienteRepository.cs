
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.UserMasterCliente
{
    public interface IUserMasterClienteRepository
    {
        Task<IEnumerable<UserMasterClienteEntity>> GetUserMastersCliente();
        Task<UserMasterClienteEntity> GetUsersByMasterCliente(Guid userMasterClienteIdentityId);
    }
}
