using Easy.Domain.Entities.UserMasterCliente;

namespace Easy.Domain.Intefaces.Repository.UserMasterCliente;

public interface IUserMasterClienteRepository
{
    Task<IEnumerable<UserMasterClienteEntity>> GetMembersAsync();
    Task<UserMasterClienteEntity> GetMemberByIdAsync(Guid userCli);
    Task<UserMasterClienteEntity> AddMemberAsync(UserMasterClienteEntity userCli);
    void UpdateMember(UserMasterClienteEntity userCli);
    Task<UserMasterClienteEntity> DeleteMember(Guid userCli);
}
