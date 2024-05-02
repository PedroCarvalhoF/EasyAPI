using Domain.Dtos.ProdutoDtos;

namespace Domain.Interfaces.Services.Produto
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> Get();
        Task<ProdutoDto> Get(Guid id);
        Task<ProdutoDto> GetCodigo(string codigoPersonalizado);
        Task<IEnumerable<ProdutoDto>> Get(string nomeProduto);
        Task<IEnumerable<ProdutoDto>> GetCategoria(Guid categoriaId);
        Task<IEnumerable<ProdutoDto>> GetMedida(Guid medidaId);
        Task<IEnumerable<ProdutoDto>> GetProdutoTipo(Guid produtoTipoId);
        Task<IEnumerable<ProdutoDto>> GetHabilitadoNaoHabilitado(bool habilitado);
        Task<ProdutoDto> Cadastrar(ProdutoDtoCreate produtoDtoCreate);
        Task<ProdutoDto> Alterar(ProdutoDtoUpdate produtoDtoUpdate);
    }
}
