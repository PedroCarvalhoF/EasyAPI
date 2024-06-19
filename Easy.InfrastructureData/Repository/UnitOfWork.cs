using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Repository.UsuarioMasterCliente;

namespace Easy.InfrastructureData.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IUsuarioMasterClienteRepository _userMClienteRepository;
    private readonly MyContext _context;

    public UnitOfWork(MyContext context)
    {
        _context = context;
    }

    public IUsuarioMasterClienteRepository UsuarioMasterClienteRepository
    {
        get
        {
            return _userMClienteRepository = _userMClienteRepository ?? 
                new UsuarioMasterClienteRepository(_context);
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
