using Easy.Domain.Entities;
using Easy.Services.DTOs.CategoriaProduto;

namespace Easy.Services.Service.CategoriaProduto;

public interface ICategoriaProdutoService<F> where F : FiltroBase
{
    Task<CategoriaProdutoView> SelectAsync(Guid idCategoria, F filtro);
    Task<IEnumerable<CategoriaProdutoView>> SelectAsync(F filtro);

}
