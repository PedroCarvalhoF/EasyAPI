using Api.Domain.Entities.Pedido;
using Domain.Enuns;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<PedidoEntity>> Get(SituacaoPedidoEnum situacaoPedido);
        Task<IEnumerable<PedidoEntity>> SelectAsync(Expression<Func<PedidoEntity, bool>> funcao, bool inlude = true);
    }
}
