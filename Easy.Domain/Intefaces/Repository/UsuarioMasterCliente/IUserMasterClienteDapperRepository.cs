using Easy.Domain.Entities.UserMasterCliente;

namespace Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;

public interface IUserMasterClienteDapperRepository
{
    Task<IEnumerable<UserMasterClienteEntity>> GetUsersMastersClientesAsync();
    Task<UserMasterClienteEntity> GetUserMasterClienteByIdAsync(Guid id);
}
