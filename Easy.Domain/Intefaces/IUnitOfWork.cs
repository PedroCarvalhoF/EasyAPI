using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    IUserMasterClienteRepository<UserMasterClienteEntity> UserMasterClienteRepository { get; }
    IUserMasterUserRepository<UserMasterUserEntity> UserMasterUserRepository { get; }
    Task<bool> CommitAsync();
}
