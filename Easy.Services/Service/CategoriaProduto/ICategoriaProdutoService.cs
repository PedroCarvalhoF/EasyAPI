using Easy.Domain.Entities;
using Easy.Services.DTOs.CategoriaProduto;

namespace Easy.Services.Service.CategoriaProduto;

public interface ICategoriaProdutoService<F> where F : FiltroBase
{
    Task<CategoriaProdutoDto> SelectAsync(Guid idCategoria, F filtro);
    Task<IEnumerable<CategoriaProdutoDto>> SelectAsync(F filtro);

}
