using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;

namespace Easy.Domain.Intefaces.Repository.Produto.Categoria;

public interface ICategoriaProdutoRepository<T, F> where T : CategoriaProdutoEntity where F : FiltroBase
{
    Task<IEnumerable<T>> SelectAsync(CategoriaProdutoEntityFilter filter, F filtro, bool includeAll = true);
}
