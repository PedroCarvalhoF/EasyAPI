using Api.Domain.Entities.ProdutoMedida;

namespace Domain.Repository
{
    public interface IProdutoMedidaRepository
    {
        Task<IEnumerable<ProdutoMedidaEntity>> Get(string descricao);
    }
}
