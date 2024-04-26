using Api.Domain.Dtos.CategoriaPrecoDtos;

namespace Api.Domain.Interfaces.Services.CategoriaPreco
{
    public interface ICategoriaPrecoService
    {

        Task<IEnumerable<CategoriaPrecoDto>> GetAll();
        Task<CategoriaPrecoDto> Get(Guid id);       
        Task<CategoriaPrecoDto> Create(CategoriaPrecoDtoCreate create);
        Task<CategoriaPrecoDto> Update(CategoriaPrecoDtoUpdate update);
        Task<bool> Desabilitar(Guid id);
    }
}