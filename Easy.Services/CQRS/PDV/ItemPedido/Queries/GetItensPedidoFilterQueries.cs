using Easy.Domain.Entities.PDV.ItensPedido;

namespace Easy.Services.CQRS.PDV.ItemPedido.Queries;

public class GetItensPedidoFilterQueries
{
    public Guid? PedidoId { get; set; }
    public Guid? ProdutoId { get; set; }
    public bool? Cancelado { get; set; }
    public static IQueryable<ItemPedidoEntity> QueryablePedidoEntity(IQueryable<ItemPedidoEntity> query, GetItensPedidoFilterQueries filtro)
    {
        if (filtro.PedidoId.HasValue)
        {
            query = query.Where(item => item.PedidoId == filtro.PedidoId);
        }
        if (filtro.ProdutoId.HasValue)
        {
            query = query.Where(item => item.ProdutoId == filtro.ProdutoId);
        }
        if (filtro.Cancelado.HasValue)
        {
            query = query.Where(item => item.Cancelado == filtro.Cancelado);
        }

        return query;
    }
}
