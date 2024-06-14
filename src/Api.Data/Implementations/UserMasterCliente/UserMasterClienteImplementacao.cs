using Api.Data.Context;
using Data.Repository;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.IQueres;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.UserMasterCliente
{
    public class UserMasterClienteImplementacao : RepositoryGeneric<UserMasterClienteEntity>, IUserMasterClienteRepository
    {
        private readonly DbSet<UserMasterClienteEntity> _dbSet;
        private readonly IQueryBase<UserMasterClienteEntity> _query;
        public UserMasterClienteImplementacao(MyContext context, IQueryBase<UserMasterClienteEntity> query) : base(context)
        {
            _dbSet = context.Set<UserMasterClienteEntity>();
            _query = query;
        }

        public async Task<IEnumerable<UserMasterClienteEntity>> GetUserMastersCliente()
        {
            IQueryable<UserMasterClienteEntity> query = _dbSet.AsNoTracking();

            query = _query.FullInclude(query);

            return await query.ToArrayAsync();
        }
    }
}
