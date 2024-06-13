using Api.Domain.Entities;
using Domain.UserIdentity.MasterUsers;

namespace Data.Query
{
    public static class QueryBuilder
    {
        public static IQueryable<T> FiltroUserMasterCliente<T>(this IQueryable<T> query, UserMasterUserEntity user) where T : BaseEntity
        {
            return query.Where(p => p.UserMasterClienteIdentityId == user.UserMasterClienteIdentityId);
        }

        public static IQueryable<T> FiltroUserMasterClienteUser<T>(this IQueryable<T> query, UserMasterUserEntity user) where T : BaseEntity
        {
            return query.Where(p => p.UserMasterClienteIdentityId == user.UserMasterClienteIdentityId && p.UserId == user.UserId);
        }
    }
}