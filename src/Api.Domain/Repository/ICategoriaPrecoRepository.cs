using Api.Domain.Entities.CategoriaPreco;

namespace Domain.Repository
{
    public interface ICategoriaPrecoRepository
    {
        Task<IEnumerable<CategoriaPrecoEntity>> ConsultarTodasCategoriasPrecosIncludeProdutos();
    }
}
