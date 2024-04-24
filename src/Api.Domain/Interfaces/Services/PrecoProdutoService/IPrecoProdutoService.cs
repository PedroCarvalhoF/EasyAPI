using Api.Domain.Dtos.PrecoProdutoDtos;

namespace Api.Domain.Interfaces.Services.PrecoProdutoService
{
    public interface IPrecoProdutoService
    {
        Task<PrecoProdutoDto> CadastrarPrecoProduto(PrecoProdutoDtoCreate precoProdutoDtoCreate);
        Task<PrecoProdutoDto> ConsultarPrecoByID(Guid id);
        Task<IEnumerable<PrecoProdutoDto>> ConsultarPrecoProduto();
        Task<IEnumerable<PrecoProdutoDto>> GetPrecosByCategoriaPrecoID(Guid categoriaId);
        Task<IEnumerable<PrecoProdutoDto>> GetPrecosByProdutoID(Guid produtoId);
    }
}