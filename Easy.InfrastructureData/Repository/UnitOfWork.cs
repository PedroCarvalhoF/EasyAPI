#region Usings
using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;
using Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.PDV.CategoraPreco;
using Easy.InfrastructureData.Repository.PDV.FormaPagamento;
using Easy.InfrastructureData.Repository.PDV.PrecoProduto;
using Easy.InfrastructureData.Repository.Produto;
using Easy.InfrastructureData.Repository.Produto.Categoria;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Easy.InfrastructureData.Repository.UserMasterUser;
using Microsoft.AspNetCore.Identity;

#endregion
namespace Easy.InfrastructureData.Repository;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyContext _context;

    private IUserMasterClienteRepository<UserMasterClienteEntity> _userMasterClienteRepository;
    private IUserMasterUserRepository<UserMasterUserEntity> _userMasterUserRepository;
    private ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> _categorioProdutoRepository;
    private IProdutoRepository<ProdutoEntity, FiltroBase> _produtoRepository;
    private IFormaPagamentoRepository<FormaPagamentoEntity, FiltroBase> _formaPagamentoRepository;
    private ICategoriaPrecoRepository<CategoriaPrecoEntity, FiltroBase> _categoriaPrecoRepository;
    private IPrecoProdutoRepository<PrecoProdutoEntity, FiltroBase> _precoProdutoRepository;
    //Using Base - teste
    private IBaseRepository<CategoriaProdutoEntity> _categoriaProdutoBaseRepository;
    public UnitOfWork(MyContext context)
    {
        _context = context;
    }

    public IUserMasterClienteRepository<UserMasterClienteEntity> UserMasterClienteRepository
    {
        get
        {
            return _userMasterClienteRepository = _userMasterClienteRepository ??
                new UserMasterClienteRepository<UserMasterClienteEntity>(_context);
        }
    }
    public IUserMasterUserRepository<UserMasterUserEntity> UserMasterUserRepository
    {
        get
        {
            return _userMasterUserRepository = _userMasterUserRepository ??
                new UserMasterUserRepository<UserMasterUserEntity>(_context);
        }
    }
    public ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> CategoriaProdutoRepository
    {
        get
        {
            return _categorioProdutoRepository = _categorioProdutoRepository ??
                new CategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase>(_context);
        }
    }
    public IProdutoRepository<ProdutoEntity, FiltroBase> ProdutoRepository
    {
        get
        {
            return _produtoRepository = _produtoRepository ??
                new ProdutoRepository<ProdutoEntity, FiltroBase>(_context);
        }
    }
    public IFormaPagamentoRepository<FormaPagamentoEntity, FiltroBase> FormaPagamentoRepository
    {
        get
        {
            return _formaPagamentoRepository = _formaPagamentoRepository ??
                new FormaPagamentoRepository<FormaPagamentoEntity, FiltroBase>(_context);
        }
    }
    public ICategoriaPrecoRepository<CategoriaPrecoEntity, FiltroBase> CategoriaPrecoRepository
    {
        get
        {
            return _categoriaPrecoRepository = _categoriaPrecoRepository ??
                new CategoriaPrecoRepository<CategoriaPrecoEntity, FiltroBase>(_context);
        }
    }

    public IPrecoProdutoRepository<PrecoProdutoEntity, FiltroBase> PrecoProdutoRepository
    {
        get
        {
            return _precoProdutoRepository = _precoProdutoRepository ??
                new PrecoProdutoRepository<PrecoProdutoEntity, FiltroBase>(_context);
        }
    }

    //TEMP TESTE CATEGORIA COM BASE REPOSITORY
    public IBaseRepository<CategoriaProdutoEntity> CategoriaProdutoBaseRepository
    {
        get
        {
            return _categoriaProdutoBaseRepository = _categoriaProdutoBaseRepository ??
                new BaseRepository<CategoriaProdutoEntity>(_context);
        }
    }


    public async Task<bool> CommitAsync()
    {
        var result = await _context.SaveChangesAsync();
        if (result > 0)
            return true;
        return false;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
