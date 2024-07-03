using Easy.Domain.Entities;

namespace Easy.InfrastructureData.Tools
{
    public static class BuilderFiltroBase
    {
        public static IQueryable<T> FiltroCliente<T>(this IQueryable<T> query, FiltroBase user) where T : BaseEntity
        {
            return query.Where(p => p.UserMasterClienteIdentityId == user.clienteId);
        }
    }
}
