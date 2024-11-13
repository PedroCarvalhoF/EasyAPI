using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Periodo;

namespace Easy.Domain.Intefaces.Repository.PDV.Periodo;

public interface IPeriodoPdvRepository<T, F> where T : PeriodoPdvEntity where F : FiltroBase
{
    Task<IEnumerable<T>> SelectAsync(PeriodoPdvEntityFilter filter, F filtro, bool includeAll = true);
}
