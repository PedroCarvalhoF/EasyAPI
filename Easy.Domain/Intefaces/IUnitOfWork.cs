#region Usings
using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;
using Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.UserPDV;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;

#endregion
namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    IUserMasterClienteRepository<UserMasterClienteEntity> UserMasterClienteRepository { get; }
    IUserMasterUserRepository<UserMasterUserEntity> UserMasterUserRepository { get; }
    ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> CategoriaProdutoRepository { get; }
    IProdutoRepository<ProdutoEntity, FiltroBase> ProdutoRepository { get; }
    IFormaPagamentoRepository<FormaPagamentoEntity, FiltroBase> FormaPagamentoRepository { get; }
    ICategoriaPrecoRepository<CategoriaPrecoEntity, FiltroBase> CategoriaPrecoRepository { get; }
    IPrecoProdutoRepository<PrecoProdutoEntity, FiltroBase> PrecoProdutoRepository { get; }

    IUsuarioPdvRepository<UsuarioPdvEntity, FiltroBase> UsuarioPdvRepository { get; }

    //TEMP TESTE COM BASE REPOSITORY
    IBaseRepository<CategoriaProdutoEntity> CategoriaProdutoBaseRepository { get; }
    Task<bool> CommitAsync();
}
