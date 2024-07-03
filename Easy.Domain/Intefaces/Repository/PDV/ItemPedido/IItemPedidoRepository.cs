using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.ItensPedido;

namespace Easy.Domain.Intefaces.Repository.PDV.ItemPedido;

public interface IItemPedidoRepository<T, F> where T : ItemPedidoEntity where F : FiltroBase
{
    Task<IEnumerable<T>> SelectAsync(ItemPedidoEntityFilter itemFiltro, F filtro);
}
