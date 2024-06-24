using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UserMasterUser;

public class UserMasterUserRepository<T> : IUserMasterUserRepository<T> where T : UserMasterUserEntity
{
    private readonly MyContext _context;

    public UserMasterUserRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<T> Cadastrar(T create)
    {
        if (create == null)
            throw new ArgumentNullException(nameof(create));

        await _context.Set<T>().AddAsync(create);
        return create;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToArrayAsync();
    }

    public async Task<T> GetById(Guid userId)
    {
        return await _context.Set<T>().FindAsync(userId);
    }
}
