#region Usings
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.Produto.Categoria;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Easy.InfrastructureData.Repository.UserMasterUser;
using Microsoft.AspNetCore.Identity;

#endregion
namespace Easy.InfrastructureData.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private IUserMasterClienteRepository<UserMasterClienteEntity> _userMasterClienteRepository;
    private IUserMasterUserRepository<UserMasterUserEntity> _userMasterUserRepository;
    private ICategoriaProdutoRepository<CategoriaProdutoEntity, FiltroBase> _categorioProdutoRepository;

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
    public IUserMasterUserRepository<UserMasterUserEntity> UserMasterUserRepository    {
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
