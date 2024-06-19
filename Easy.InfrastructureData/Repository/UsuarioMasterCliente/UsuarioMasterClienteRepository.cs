using Easy.Domain.Entities.UserMasterCliente;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UsuarioMasterCliente;

public class UsuarioMasterClienteRepository 
{
    private readonly MyContext db;
    public UsuarioMasterClienteRepository(MyContext context)
    {
        db = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<UserMasterClienteEntity>> GetAllAsync()
    {
        return await db.UserMasterCliente.Include(user=>user.UserMaster).ToArrayAsync();
    }

    public async Task<UserMasterClienteEntity> GetByIdAsync(Guid id)
    {
        return await db.UserMasterCliente.FindAsync(id);

    }

    public async Task<UserMasterClienteEntity> InsertAsync(UserMasterClienteEntity item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        await db.UserMasterCliente.AddAsync(item);
        return item;
    }
}
