using Easy.Domain.Entities;
using Easy.Services.DTOs.CategoriaProduto;

namespace Easy.Services.Service.CategoriaProduto;

public class CategoriaProdutoService : ICategoriaProdutoService<FiltroBase>
{
    public Task<CategoriaProdutoDto> SelectAsync(Guid idCategoria, FiltroBase filtro)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoriaProdutoDto>> SelectAsync(FiltroBase filtro)
    {
        throw new NotImplementedException();
    }
}
