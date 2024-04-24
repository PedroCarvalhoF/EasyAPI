using Api.Domain.Dtos.CategoriaPrecoDtos;

namespace Api.Domain.Interfaces.Services.CategoriaPreco
{
    public interface ICategoriaPrecoService
    {

        Task<CategoriaPrecoDtoCreateResult> Cadastrar(CategoriaPrecoDtoCreate categoriaPrecoDtoCreate);
        Task<IEnumerable<CategoriaPrecoDto>> ConsultarTodos();
    }
}