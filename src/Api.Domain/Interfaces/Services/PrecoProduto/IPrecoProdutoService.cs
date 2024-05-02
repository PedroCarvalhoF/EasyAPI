using Api.Domain.Dtos.PrecoProdutoDtos;

namespace Api.Domain.Interfaces.Services.PrecoProdutoService
{
    public interface IPrecoProdutoService
    {
        Task<IEnumerable<PrecoProdutoDto>> GetAll();
        Task<PrecoProdutoDto> Get(Guid id);
        Task<PrecoProdutoDto> CreateUpdate(PrecoProdutoDtoCreate create);
        Task<IEnumerable<PrecoProdutoDto>> GetProdutoId(Guid id);
        Task<IEnumerable<PrecoProdutoDto>> GetCategoriaPrecoId(Guid id);
        //Task<bool> Desabilitar(Guid id);
    }
}