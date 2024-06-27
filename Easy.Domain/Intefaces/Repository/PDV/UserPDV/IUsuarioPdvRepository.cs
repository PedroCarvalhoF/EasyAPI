using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Enuns.Pdv.UserPDV;

namespace Easy.Domain.Intefaces.Repository.PDV.UserPDV;

public interface IUsuarioPdvRepository<T, F> where T : UsuarioPdvEntity where F : FiltroBase
{
    Task<T> InsertAsync(T item, F filtro);
    Task<T> UpdateAsync(T item, F filtro);
    Task<IEnumerable<T>> SelectAsync(F filtro);
    Task<IEnumerable<T>> SelectAsync(UsuarioPdvFiltroEnum filtroEnum, F filtro);
    Task<T>? SelectByIdUsuarioPdvAsync(Guid idUsuarioPdv, F filtro);

}
