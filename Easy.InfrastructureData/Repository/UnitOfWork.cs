using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.UserMasterCliente;
using Microsoft.AspNetCore.Identity;

namespace Easy.InfrastructureData.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private IUserMasterClienteRepository? _userMasterClienteRepository;
    private IRepositoryGeneric<UserMasterUserEntity> _userMasterClienteRespository;

    public UnitOfWork(MyContext context, UserManager<UserEntity> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public UserManager<UserEntity> UserManager
    {
        get
        {
            return _userManager;
        }
    }

    public IUserMasterClienteRepository UserMasterClienteRepository
    {
        get
        {
            return _userMasterClienteRepository = _userMasterClienteRepository ??
                new UserMasterClienteRepository(_context);
        }
    }

    public IRepositoryGeneric<UserMasterUserEntity> UserMasterUserRepository
    {
        get
        {
            return _userMasterClienteRespository = _userMasterClienteRespository ??
               new RepositoryGeneric<UserMasterUserEntity>(_context);
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
