using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Domain.IQueres.UserMasterCliente
{
    public class UserMasterClienteQuery<T> : IUserMasterClienteQuery<IQueryable<UserMasterClienteEntity>>
    {
        public IQueryable<UserMasterClienteEntity> FullInclude(IQueryable<UserMasterClienteEntity> query)
        {
            query = query.Include(um => um.UserMaster)
                         .Include(um => um.UsersMasterUsers)
                         .ThenInclude(user => user.User);
            return query;
        }

        public IQueryable<UserMasterClienteEntity> WhereByClienteMaster(IQueryable<UserMasterClienteEntity> query, Guid idClienteMaster)
        {
            return
                query.Where(uM => uM.UserMasterId == idClienteMaster);

            throw new NotImplementedException();
        }
    }
}
