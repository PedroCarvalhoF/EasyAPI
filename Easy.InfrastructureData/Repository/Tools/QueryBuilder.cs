using Easy.Domain.Entities;

namespace Easy.InfrastructureData.Repository.Tools;

public static class QueryBuilder
{
    public static IQueryable<T> AplicarFiltroCliente<T>(this IQueryable<T> query, FiltroBase filter) where T : BaseEntity
    {
        return query.Where(p => p.UserMasterClienteIdentityId == filter.clienteId);
    }

    public static IQueryable<T> FiltroUserMasterClienteUser<T>(this IQueryable<T> query, FiltroBase filter) where T : BaseEntity
    {
        return query.Where(p => p.UserMasterClienteIdentityId == filter.clienteId && p.UserId == filter.userId);
    }
}