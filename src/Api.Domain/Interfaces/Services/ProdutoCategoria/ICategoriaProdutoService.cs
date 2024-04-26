using Api.Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos.CategoriaProdutoDtos;

namespace Api.Domain.Interfaces.Services.CategoriaProduto
{
    public interface ICategoriaProdutoService
    {
        Task<CategoriaProdutoDto> Create(CategoriaProdutoDtoCreate create);
        Task<CategoriaProdutoDto> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate);

        Task<IEnumerable<CategoriaProdutoDto>> Get();
        Task<CategoriaProdutoDto> Get(Guid id);
        Task<IEnumerable<CategoriaProdutoDto>> Get(string categoria);
        Task<bool> DesabilitarHabilitar(Guid id);

    }
}
