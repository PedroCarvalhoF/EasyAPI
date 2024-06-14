using Api.Data.Context;
using Data.Repository;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.IQueres.UserMasterCliente;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.UserMasterCliente
{
    public class UserMasterClienteImplementacao : RepositoryGeneric<UserMasterClienteEntity>, IUserMasterClienteRepository
    {
        private readonly DbSet<UserMasterClienteEntity> _dbSet;
        private readonly IUserMasterClienteQuery<IQueryable<UserMasterClienteEntity>> _userMasterClienteQuery;
        public UserMasterClienteImplementacao(MyContext context, IUserMasterClienteQuery<IQueryable<UserMasterClienteEntity>> userMasterClienteQuery) : base(context)
        {
            _dbSet = context.Set<UserMasterClienteEntity>();
            _userMasterClienteQuery = userMasterClienteQuery;
        }

        public async Task<IEnumerable<UserMasterClienteEntity>> GetUserMastersCliente()
        {
            IQueryable<UserMasterClienteEntity> query = _dbSet.AsNoTracking();
            query = _userMasterClienteQuery.FullInclude(query);
            //query = _userMasterClienteQuery.WhereByClienteMaster(query, Guid.NewGuid());
            return await query.ToArrayAsync();
        }

        public async Task<UserMasterClienteEntity> GetUsersByMasterCliente(Guid userMasterClienteIdentityId)
        {
            IQueryable<UserMasterClienteEntity> query = _dbSet.AsNoTracking();
            
            query = _userMasterClienteQuery.FullInclude(query);
            
            query = _userMasterClienteQuery.WhereByClienteMaster(query, userMasterClienteIdentityId);

            return await query.SingleOrDefaultAsync();
        }
    }
}
