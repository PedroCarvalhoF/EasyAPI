#region Usings
using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;
using Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;
using Easy.Domain.Intefaces.Repository.PDV.ItemPedido;
using Easy.Domain.Intefaces.Repository.PDV.PagamentoPedido;
using Easy.Domain.Intefaces.Repository.PDV.Pdv;
using Easy.Domain.Intefaces.Repository.PDV.Pedido;
using Easy.Domain.Intefaces.Repository.PDV.Periodo;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.Domain.Intefaces.Repository.PDV.UserPDV;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.PDV.CategoraPreco;
using Easy.InfrastructureData.Repository.PDV.FormaPagamento;
using Easy.InfrastructureData.Repository.PDV.ItemPedido;
using Easy.InfrastructureData.Repository.PDV.PagamentoPedido;
using Easy.InfrastructureData.Repository.PDV.PDV;
using Easy.InfrastructureData.Repository.PDV.Pedido;
using Easy.InfrastructureData.Repository.PDV.Periodo;
using Easy.InfrastructureData.Repository.PDV.PrecoProduto;
using Easy.InfrastructureData.Repository.PDV.UsuarioPdv;
using Easy.InfrastructureData.Repository.Produto;
using Easy.InfrastructureData.Repository.Produto.Categoria;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Easy.InfrastructureData.Repository.UserMasterUser;
using Microsoft.EntityFrameworkCore;

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
    private IUsuarioPdvRepository<UsuarioPdvEntity, FiltroBase> _usuarioPdvRepository;
    private IPeriodoPdvRepository<PeriodoPdvEntity, FiltroBase> _periodoPdvRepository;
    private IPontoVendaRepository<PontoVendaEntity, FiltroBase> _pontoVendaRepository;
    private IPedidoRepository<PedidoEntity, FiltroBase> _pedidoRepository;
    private IItemPedidoRepository<ItemPedidoEntity, FiltroBase> _itemPedidoRepository;
    private IPagamentoPedidoRepository<PagamentoPedidoEntity, FiltroBase> _pagamentoPedidoRepository;

    private IBaseRepository<CategoriaProdutoEntity> _categoriaProdutoBaseRepository;
    private IBaseRepository<PontoVendaEntity> _pontoVendaBaseRepository;
    private IBaseRepository<PedidoEntity> _pedidoBaseRepository;
    private IBaseRepository<ItemPedidoEntity> _itemPedidoBaseRepository;
    private IBaseRepository<PagamentoPedidoEntity> _pagamentoPedidoBaseRepository;
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
                new CategoriaPrecoRepository(_context);
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
    public IUsuarioPdvRepository<UsuarioPdvEntity, FiltroBase> UsuarioPdvRepository
    {
        get
        {
            return _usuarioPdvRepository = _usuarioPdvRepository ??
                new UsuarioPdvRepository<UsuarioPdvEntity, FiltroBase>(_context);
        }
    }
    public IPeriodoPdvRepository<PeriodoPdvEntity, FiltroBase> PeriodoPdvRepository
    {
        get
        {
            return _periodoPdvRepository = _periodoPdvRepository ??
                new PeriodoPdvRepository<PeriodoPdvEntity, FiltroBase>(_context);
        }
    }
    public IPontoVendaRepository<PontoVendaEntity, FiltroBase> PontoVendaRepository
    {
        get
        {
            return _pontoVendaRepository = _pontoVendaRepository ??
                new PontoVendaRepository(_context);
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
    public IBaseRepository<PontoVendaEntity> PontoVendaBaseRepository
    {
        get
        {
            return _pontoVendaBaseRepository = _pontoVendaBaseRepository ??
                new BaseRepository<PontoVendaEntity>(_context);
        }
    }
    public IPedidoRepository<PedidoEntity, FiltroBase> PedidoRepository
    {
        get
        {
            return _pedidoRepository = _pedidoRepository ??
                new PedidoRepository(_context);
        }
    }
    public IBaseRepository<PedidoEntity> PedidoBaseRepository
    {
        get
        {
            return _pedidoBaseRepository = _pedidoBaseRepository ??
                new BaseRepository<PedidoEntity>(_context);
        }
    }
    public IItemPedidoRepository<ItemPedidoEntity, FiltroBase> ItemPedidoRepository
    {
        get
        {
            return _itemPedidoRepository = _itemPedidoRepository ??
                new ItemPedidoRepository(_context);
        }
    }
    public IBaseRepository<ItemPedidoEntity> ItemPedidoBaseRepository
    {
        get
        {
            return _itemPedidoBaseRepository = _itemPedidoBaseRepository ??
                new ItemPedidoRepository(_context);
        }
    }
    public IPagamentoPedidoRepository<PagamentoPedidoEntity, FiltroBase> PagamentoPedidoRespoitory
    {
        get
        {
            return _pagamentoPedidoRepository = _pagamentoPedidoRepository ??
                new PagamentoPedidoRepository(_context);
        }
    }
    public IBaseRepository<PagamentoPedidoEntity> PagamentoPedidoBaseRepository
    {
        get
        {
            return _pagamentoPedidoBaseRepository = _pagamentoPedidoBaseRepository ??
                new BaseRepository<PagamentoPedidoEntity>(_context);
        }
    }
    public async Task<bool> CommitAsync()
    {
        try
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException.Message != null)
                throw new Exception(ex.InnerException.Message);

            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
        finally
        {

        }

    }

    public void FinalizarContexto()
    {
        Dispose();
    }
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
