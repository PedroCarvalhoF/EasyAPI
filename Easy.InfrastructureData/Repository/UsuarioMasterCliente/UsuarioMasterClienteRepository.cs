using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UsuarioMasterCliente;

public class UsuarioMasterClienteRepository : IUsuarioMasterClienteRepository
{
    private readonly MyContext db;
    public UsuarioMasterClienteRepository(MyContext context)
    {
        db = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<UserMasterClienteEntity>> GetAllAsync()
    {
        return await db.UserMasterClienteEntity.Include(user=>user.UserMaster).ToArrayAsync();
    }

    public async Task<UserMasterClienteEntity> GetByIdAsync(Guid id)
    {
        return await db.UserMasterClienteEntity.FindAsync(id);

    }

    public async Task<UserMasterClienteEntity> InsertAsync(UserMasterClienteEntity item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        await db.UserMasterClienteEntity.AddAsync(item);
        return item;
    }
}
