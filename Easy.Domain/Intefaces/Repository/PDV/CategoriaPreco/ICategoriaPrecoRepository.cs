using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.CategoriaPreco;

namespace Easy.Domain.Intefaces.Repository.PDV.CategoriaPreco;

public interface ICategoriaPrecoRepository<T, F> where T : CategoriaPrecoEntity where F : FiltroBase
{
    Task<CategoriaPrecoEntity> InsertAsync(T item, F filtro);
    Task<CategoriaPrecoEntity> UpdateAsync(T item, F filtro);
    Task<bool> DeleteAsync(Guid id, F userFiltro);
    Task<CategoriaPrecoEntity> SelectAsync(Guid id, F filtro);
    Task<IEnumerable<CategoriaPrecoEntity>> SelectAsync(F filtro);
    Task<bool> CodigoDescricaoExists(int codigo, string descricao, F filtro);
}