using Domain.Entities.ItensPedido;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedidoEntity> GetByIdItemPedido(Guid idItemPedido);
        Task<IEnumerable<ItemPedidoEntity>> GetByIdProduto(Guid idProduto, bool fullConsulta);

        Task<IEnumerable<ItemPedidoEntity>> SelectAsync(Expression<Func<ItemPedidoEntity, bool>> funcao, bool fullConsulta = false);
    }
}
