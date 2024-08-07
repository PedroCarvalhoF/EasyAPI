using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UserMasterUser;

public class UserMasterUserRepository<T> : IUserMasterUserRepository<UserMasterUserEntity>
{
    private readonly MyContext _context;

    public UserMasterUserRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<UserMasterUserEntity> Cadastrar(UserMasterUserEntity create)
    {
        if (create == null)
            throw new ArgumentNullException(nameof(create));
        await _context.Set<UserMasterUserEntity>().AddAsync(create);

        return create;
    }

    public async Task<UserMasterUserEntity> GetById(Guid userId)
    {
        try
        {
            var result =
                await _context.Set<UserMasterUserEntity>().AsNoTracking()
                .Where(uM => uM.UserMasterUserId == userId)
                .Include(u => u.UserMasterUser)
                .SingleOrDefaultAsync();

            return result;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
