using Easy.Domain.Entities.PDV.UserPDV;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Tools.UsuarioPdv
{
    public static class UsuarioPdvEntityExtensionsInclude
    {
        public static IQueryable<T> FullInclude<T>(this IQueryable<T> query) where T : UsuarioPdvEntity
        {
            query = query.Include(user=>user.UserPdv);

            return query;
        }
    }
}
