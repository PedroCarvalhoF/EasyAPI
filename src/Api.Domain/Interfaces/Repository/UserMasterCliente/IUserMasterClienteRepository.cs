
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;

namespace Domain.Interfaces.Repository.UserMasterCliente
{
    public interface IUserMasterClienteRepository
    {
        Task<IEnumerable<UserMasterClienteEntity>> GetUserMastersCliente();
    }
}
