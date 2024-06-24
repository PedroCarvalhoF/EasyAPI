using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface IProdutoRepository<T, F> where T : ProdutoEntity where F : FiltroBase
    {
        Task<ProdutoEntity> InsertAsync(T item, F userFiltro);
        Task<ProdutoEntity> UpdateAsync(T item, F userFiltro);
        Task<bool> DeleteAsync(Guid id, F userFiltro);
        Task<ProdutoEntity> SelectAsync(Guid id, F userFiltro);
        Task<IEnumerable<ProdutoEntity>> SelectAsync(F userFiltro);       
        Task<bool> CodigoNomeExists(string codigo, string nome, F userFiltro);
    }
}
