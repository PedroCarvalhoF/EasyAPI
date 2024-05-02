using Domain.Entities.PedidoSituacao;

namespace Domain.Interfaces.Repository.PedidoSituacao
{
    public interface ISituacaoPedidoRepository
    {
        Task<IEnumerable<SituacaoPedidoEntity>> Get(string descricao);
    }
}
