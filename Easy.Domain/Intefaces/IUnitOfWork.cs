using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    IUsuarioMasterClienteRepository UsuarioMasterClienteRepository { get; }
    UserManager<UserEntity> UserManager { get; }
    Task CommitAsync();
}
