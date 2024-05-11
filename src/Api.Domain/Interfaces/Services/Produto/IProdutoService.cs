using Domain.Dtos;
using Domain.Dtos.ProdutoDtos;

namespace Domain.Interfaces.Services.Produto
{
    public interface IProdutoService
    {
        Task<ResponseDto<List<ProdutoDto>>> Get();
        Task<ResponseDto<List<ProdutoDto>>> Get(Guid id);
        Task<ResponseDto<List<ProdutoDto>>> GetCodigo(string codigoPersonalizado);
        Task<ResponseDto<List<ProdutoDto>>> Get(string nomeProduto);
        Task<ResponseDto<List<ProdutoDto>>> GetCategoria(Guid categoriaId);
        Task<ResponseDto<List<ProdutoDto>>> GetMedida(Guid medidaId);
        Task<ResponseDto<List<ProdutoDto>>> GetProdutoTipo(Guid produtoTipoId);
        Task<ResponseDto<List<ProdutoDto>>> GetHabilitadoNaoHabilitado(bool habilitado);
        Task<ResponseDto<List<ProdutoDto>>> Cadastrar(ProdutoDtoCreate produtoDtoCreate);
        Task<ResponseDto<List<ProdutoDto>>> Alterar(ProdutoDtoUpdate produtoDtoUpdate);
    }
}
