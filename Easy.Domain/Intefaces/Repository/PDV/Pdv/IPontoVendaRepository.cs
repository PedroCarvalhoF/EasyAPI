using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PDV;

namespace Easy.Domain.Intefaces.Repository.PDV.Pdv
{
    public interface IPontoVendaRepository<T, F> where T : PontoVendaEntity where F : FiltroBase
    {
        Task<T> GetPdvById(Guid idPdv, FiltroBase filtro, bool includeAll = true);
        Task<IEnumerable<T>> SelectAsync(PontoVendaQueryFilter pdvFiltro, F filtro, bool includeAll = true);
    }
}