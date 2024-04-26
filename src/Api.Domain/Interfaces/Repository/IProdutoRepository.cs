using Domain.Entities.Produto;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoEntity>> Get();
        Task<ProdutoEntity> Get(Guid id);
        Task<ProdutoEntity> GetCodigo(string codigoPersonalizado);
        Task<IEnumerable<ProdutoEntity>> Get(string nomeProduto);
        Task<IEnumerable<ProdutoEntity>> GetCategoria(Guid categoriaId);
        Task<IEnumerable<ProdutoEntity>> GetMedida(Guid categoriaId);
        Task<IEnumerable<ProdutoEntity>> GetProdutoTipo(Guid categoriaId);
        Task<IEnumerable<ProdutoEntity>> GetHabilitadoNaoHabilitado(bool habilitado);
    }
}
