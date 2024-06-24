using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;

namespace Easy.Domain.Intefaces.Repository.Produto.Categoria;

public interface ICategoriaProdutoRepository<T, F> where T : CategoriaProdutoEntity where F : FiltroBase
{
    Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasProdutoAsync(F users);
    Task<CategoriaProdutoEntity> GetById(Guid userClienteId, F users);
    Task<CategoriaProdutoEntity> Create(T create);
    CategoriaProdutoEntity Update(T create);
    Task<bool> Delete(Guid id, F users);
}
