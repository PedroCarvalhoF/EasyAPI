using Easy.Domain.Entities.PDV.UserPDV;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Tools.UsuarioPdv
{
    public static class UsuarioPdvEntityExtensionsInclude
    {
        public static IQueryable<UsuarioPdvEntity> IncludeProdutos(this IQueryable<UsuarioPdvEntity> query)
        {
            return query;
        }
    }
}
