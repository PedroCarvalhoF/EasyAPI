using Easy.Domain.Entities.User;

namespace Easy.Domain.Intefaces.Repository.UserMasterCliente
{
    public interface IUserMasterClienteDapperRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersClientesAsync();
    }
}
