using Api.Domain.Entities.PrecoProduto;

namespace Domain.Interfaces.Repository
{
    public interface IPrecoProdutoRepository
    {
        Task<IEnumerable<PrecoProdutoEntity>> GetAll();
        Task<PrecoProdutoEntity> Get(Guid id);
        Task<PrecoProdutoEntity> PrecoExists(Guid produtoEntityId, Guid categoriaPrecoEntityId);
        Task<IEnumerable<PrecoProdutoEntity>> GetProdutoId(Guid id);
        Task<IEnumerable<PrecoProdutoEntity>> GetCategoriaPrecoId(Guid id);
    }
}
