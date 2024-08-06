using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;

namespace Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;

public interface IPrecoProdutoRepository<T, F> where T : PrecoProdutoEntity where F : FiltroBase
{
    Task<T> InsertAsync(T item, F userFiltro);
    Task<T> UpdatePreco(T item, F userFiltro);
    Task<IEnumerable<T>> SelectAsync(F userFiltro);
    Task<T>? SelectAsync(Guid idProduto, Guid idCategoriaPreco, F userFiltro);
    Task<IEnumerable<T>> SelectPrecosByIdProdutoAsync(Guid idProduto, F userFiltro);
}
