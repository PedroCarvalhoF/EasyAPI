using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;

namespace Easy.Domain.Intefaces.Repository.Produto.Categoria;

public interface ICategoriaProdutoDapperRepository<F> where F : FiltroBase
{
    Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoEnity(F filtro);
    Task<CategoriaProdutoEntity> GetCategoriaProdutoById(Guid idCategoria, F filtro);
}
