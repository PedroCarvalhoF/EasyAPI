using Easy.Domain.Entities.PDV.Periodo;

namespace Easy.InfrastructureData.Tools.PeriodoPdv
{
    public static class PeriodoPdvExtensionsInclude
    {
        public static IQueryable<T> FullInclude<T>(this IQueryable<T> query) where T : PeriodoPdvEntity
        {
            return query;
        }
    }
}
