using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    //APENAS PERSISTENCIAS
    UserManager<UserEntity> UserManager { get; }
    IUserMasterClienteRepository UserMasterClienteRepository { get; }
    IRepositoryGeneric<UserMasterUserEntity> UserMasterUserRepository { get; }

    Task<bool> CommitAsync();
}
