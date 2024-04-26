using Api.Domain.Entities.ProdutoMedida;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoMedidaRepository
    {
        Task<IEnumerable<ProdutoMedidaEntity>> Get(string descricao);
    }
}
