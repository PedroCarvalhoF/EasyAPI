using Api.Domain.Dtos.PrecoProdutoDtos;
using Domain.Dtos;

namespace Api.Domain.Interfaces.Services.PrecoProdutoService
{
    public interface IPrecoProdutoService
    {
        Task<ResponseDto<List<PrecoProdutoDto>>> GetAll();
        Task<ResponseDto<List<PrecoProdutoDto>>> Get(Guid id);
        Task<ResponseDto<List<PrecoProdutoDto>>> CreateUpdate(PrecoProdutoDtoCreate create);
        Task<ResponseDto<List<PrecoProdutoDto>>> GetIdProduto(Guid id);
        Task<ResponseDto<List<PrecoProdutoDto>>> GetIdCategoriaPreco(Guid id);
        //Task<bool> Desabilitar(Guid id);
    }
}