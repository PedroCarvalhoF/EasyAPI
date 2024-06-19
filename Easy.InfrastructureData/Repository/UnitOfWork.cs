using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.UsuarioMasterCliente;
using Microsoft.AspNetCore.Identity;

namespace Easy.InfrastructureData.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IUsuarioMasterClienteRepository _userMClienteRepository;
    private UserManager<UserEntity> _userManager;
    private readonly MyContext _context;

    private readonly IRepositoryGeneric<UserMasterUserEntity> _userMasterUserGeneric;

    public UnitOfWork(MyContext context, UserManager<UserEntity> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IUsuarioMasterClienteRepository UsuarioMasterClienteRepository
    {
        get
        {
            return _userMClienteRepository = _userMClienteRepository ??
                new UsuarioMasterClienteRepository(_context);
        }
    }

    public IRepositoryGeneric<UserMasterUserEntity> UserMasterUserRepositoryGeneric
    {
        get
        {
            return _userMasterUserGeneric;
        }
    }

    public UserManager<UserEntity> UserManager
    {
        get
        {
            return _userManager;
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
