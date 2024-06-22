using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    //APENAS PERSISTENCIAS
    UserManager<UserEntity> UserManager { get; }
    IUserMasterClienteRepository UserMasterClienteRepository { get; }
    IRepositoryGeneric<UserMasterUserEntity> UserMasterUserRepository { get; }
    ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> CategoriaProdutoRepository { get; }
    Task<bool> CommitAsync();
}
