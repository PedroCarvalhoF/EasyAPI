using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    //APENAS PERSISTENCIAS
    UserManager<UserEntity> UserManager { get; }
    IRepositoryGeneric<UserMasterClienteEntity> UserMasterClienteRespository { get; }
    Task<bool> CommitAsync();
}
