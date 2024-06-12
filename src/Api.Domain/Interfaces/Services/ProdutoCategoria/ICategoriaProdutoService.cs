using Api.Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;

namespace Api.Domain.Interfaces.Services.CategoriaProduto
{
    public interface ICategoriaProdutoService
    {
        Task<ResponseDto<List<CategoriaProdutoDto>>> GetAll(Guid? filtroId);
        Task<ResponseDto<List<CategoriaProdutoDto>>> GetIdCategoriaProduto(Guid id, Guid? filtroId);        
        Task<ResponseDto<List<CategoriaProdutoDto>>> Create(CategoriaProdutoDtoCreate create, Guid? filtroId);       
        Task<ResponseDto<List<CategoriaProdutoDto>>> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate, Guid? filtroId);
       

    }
}
