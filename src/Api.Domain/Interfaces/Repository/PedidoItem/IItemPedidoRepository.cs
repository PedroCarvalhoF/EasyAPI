using Domain.Entities.ItensPedido;

namespace Domain.Interfaces.Repository
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedidoEntity> Get(Guid id);
        Task<ItemPedidoEntity> GetByIdPedido(Guid idPedido);
    }
}
