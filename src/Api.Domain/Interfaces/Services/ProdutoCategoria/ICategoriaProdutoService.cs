using Api.Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;

namespace Api.Domain.Interfaces.Services.CategoriaProduto
{
    public interface ICategoriaProdutoService
    {
        Task<ResponseDto<List<CategoriaProdutoDto>>> Create(CategoriaProdutoDtoCreate create);
        Task<ResponseDto<List<CategoriaProdutoDto>>> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate);

        Task<ResponseDto<List<CategoriaProdutoDto>>> Get();
        Task<ResponseDto<List<CategoriaProdutoDto>>> Get(Guid id);
        Task<ResponseDto<List<CategoriaProdutoDto>>> Get(string categoria);
        Task<ResponseDto<List<CategoriaProdutoDto>>> DesabilitarHabilitar(Guid id);

    }
}
