using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;

namespace Easy.Domain.Intefaces.Repository.PDV.Pedido;

public interface IPedidoRepository<T, F> where T : PedidoEntity where F : FiltroBase
{
    Task<IEnumerable<T>> SelectAsync(PedidoEntityFilter filter, F filtro, bool includeAll = true);
}
