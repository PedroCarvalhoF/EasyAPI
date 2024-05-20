using Domain.Entities.PagamentoPedido;

namespace Domain.Interfaces.Repository.PedidoPagamento
{
    public interface IPagamentoPedidoRepository
    {
        Task<IEnumerable<PagamentoPedidoEntity>> GetAll();
        Task<PagamentoPedidoEntity> Get(Guid idPagamento);
        Task<IEnumerable<PagamentoPedidoEntity>> GetByIdPedido(Guid idPedido);
    }
}
