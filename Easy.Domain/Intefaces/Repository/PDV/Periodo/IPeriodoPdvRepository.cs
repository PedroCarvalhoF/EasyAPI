using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Periodo;

namespace Easy.Domain.Intefaces.Repository.PDV.Periodo;

public interface IPeriodoPdvRepository<T, F>  where T : PeriodoPdvEntity where F : FiltroBase
{
    Task<T> InsertAsync(T item, F filtro);
    Task<T> Update(T item, F filto);
    Task<IEnumerable<T>> SelectAsync(F filtro);
    Task<T>? SelectAsync(Guid idPeriodo, F filtro);
    Task<T>? SelectAsync(string descricaoPerido, F filtro);
}
