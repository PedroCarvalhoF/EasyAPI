using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Domain.IQueres.UserMasterCliente
{
    public class UserMasterClienteQuery<T> : IQueryBase<UserMasterClienteEntity>
    {
        public IQueryable<UserMasterClienteEntity> FullInclude(IQueryable<UserMasterClienteEntity> query)
        {
            query = query.Include(um => um.UserMaster).Include(um => um.UsersMasterUsers).ThenInclude(user => user.User);

            return query;
        }
    }
}
