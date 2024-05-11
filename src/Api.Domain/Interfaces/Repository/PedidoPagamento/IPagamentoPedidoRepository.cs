using Domain.Entities.PagamentoPedido;

namespace Domain.Interfaces.Repository.PedidoPagamento
{
    public interface IPagamentoPedidoRepository
    {

       
        Task<IEnumerable<PagamentoPedidoEntity>> GetAll();

        Task<PagamentoPedidoEntity> Exists(Guid pedidoEntityId, Guid formaPagamentoEntityId);
        Task<IEnumerable<PagamentoPedidoEntity>> GetPagamentoPedidoByIdPedido(Guid pedidoId);
    }
}
