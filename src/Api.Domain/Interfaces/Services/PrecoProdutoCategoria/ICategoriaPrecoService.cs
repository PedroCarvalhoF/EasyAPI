using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos;

namespace Api.Domain.Interfaces.Services.CategoriaPreco
{
    public interface ICategoriaPrecoService
    {

        Task<ResponseDto<List<CategoriaPrecoDto>>> GetAll();
        Task<ResponseDto<List<CategoriaPrecoDto>>> Get(Guid id);
        Task<ResponseDto<List<CategoriaPrecoDto>>> Create(CategoriaPrecoDtoCreate create);
        Task<ResponseDto<List<CategoriaPrecoDto>>> Update(CategoriaPrecoDtoUpdate update);
        Task<ResponseDto<List<CategoriaPrecoDto>>> Desabilitar(Guid id);
    }
}