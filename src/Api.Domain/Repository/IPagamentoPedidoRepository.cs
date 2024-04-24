using Domain.Entities.PagamentoPedido;

namespace Domain.Repository
{
    public interface IPagamentoPedidoRepository
    {
        Task<IEnumerable<PagamentoPedidoEntity>> ConsultarPagamentosPedidoByIdPedido(Guid idPedido);
    }
}
