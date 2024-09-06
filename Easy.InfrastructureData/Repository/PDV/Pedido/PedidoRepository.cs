using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces.Repository.PDV.Pedido;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.Pedido;

public class PedidoRepository : BaseRepository<PedidoEntity, FiltroBase>, IPedidoRepository<PedidoEntity, FiltroBase>
{
    protected readonly MyContext _contexto;
    private DbSet<PedidoEntity> _dataset;
    public PedidoRepository(MyContext context) : base(context)
    {
        _contexto = context;
        _dataset = context.Set<PedidoEntity>();
    }

    public async Task<IEnumerable<PedidoEntity>> SelectAsync(PedidoEntityFilter filter, FiltroBase filtro, bool includeAll = true)
    {
        try
        {
            IQueryable<PedidoEntity> query = _dataset.AsNoTracking();

            query = PedidoEntityFilter.QueryablePedidoEntity(query, filter);

            query = query.FiltroCliente(filtro);

            if (includeAll)
            {
                query = query.Include(cat_preco_pedido => cat_preco_pedido.CategoriaPreco);
            }

            query = query.OrderByDescending(pedido => pedido.CreateAt);

            var result = await query.ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
