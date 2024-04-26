using Domain.Entities.PagamentoPedido;

namespace Domain.Interfaces.Repository
{
    public interface IPagamentoPedidoRepository
    {
        Task<IEnumerable<PagamentoPedidoEntity>> ConsultarPagamentosPedidoByIdPedido(Guid idPedido);
    }
}
