using Easy.Domain.Entities.PDV.CategoriaPreco;

namespace Easy.InfrastructureData.Tools.CategoriaPreco
{
    public static class CategoriaPrecoExtensionsInclude
    {
        public static IQueryable<CategoriaPrecoEntity> FullInclude(this IQueryable<CategoriaPrecoEntity> query)
        {
            return query;
        }
    }
}
