using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Microsoft.AspNetCore.Identity;

namespace Easy.InfrastructureData.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private UserManager<UserEntity> _userManager;
    private readonly MyContext _context;

    private readonly IRepositoryGeneric<UserMasterClienteEntity> _userMasterClienteRepository;

    public UnitOfWork(MyContext context, UserManager<UserEntity> userManager, IRepositoryGeneric<UserMasterClienteEntity> userMasterClienteRepository)
    {
        _context = context;
        _userManager = userManager;
        _userMasterClienteRepository = userMasterClienteRepository;
    }

    public UserManager<UserEntity> UserManager
    {
        get
        {
            return _userManager;
        }
    }
    public IRepositoryGeneric<UserMasterClienteEntity> UserMasterClienteRespository
    {
        get
        {
            return _userMasterClienteRepository;
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
