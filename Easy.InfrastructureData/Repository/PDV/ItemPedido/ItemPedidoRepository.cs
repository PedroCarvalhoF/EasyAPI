using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces.Repository.PDV.ItemPedido;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.ItemPedido;

public class ItemPedidoRepository : BaseRepository<ItemPedidoEntity,FiltroBase>, IItemPedidoRepository<ItemPedidoEntity, FiltroBase>
{
    private DbSet<ItemPedidoEntity> _dbSet;
    public ItemPedidoRepository(MyContext context) : base(context)
    {
        _dbSet = context.Set<ItemPedidoEntity>();
    }

    public Task<IEnumerable<ItemPedidoEntity>> SelectAsync(ItemPedidoEntityFilter itemFiltro, FiltroBase filtro)
    {
        throw new NotImplementedException();
    }
}
