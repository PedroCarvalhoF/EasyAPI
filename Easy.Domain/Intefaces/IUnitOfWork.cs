using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    IUserMasterClienteRepository<UserMasterClienteEntity> UserMasterClienteRepository { get; }
    IUserMasterUserRepository<UserMasterUserEntity> UserMasterUserRepository { get; }
    ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> CategoriaProdutoRepository { get; }
    IProdutoRepository<ProdutoEntity, FiltroBase> ProdutoRepository { get; }

    //TEMP TESTE COM BASE REPOSITORY
    IBaseRepository<CategoriaProdutoEntity> CategoriaProdutoBaseRepository { get; }
    Task<bool> CommitAsync();
}
