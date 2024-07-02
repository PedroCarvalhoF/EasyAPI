namespace Easy.Domain.Entities.PDV.Pedido;

public class PedidoEntityFilter
{
    public bool Include { get; set; } = false;
    public Guid? IdPedido { get; set; }
    public static IQueryable<PedidoEntity> QueryablePedidoEntity(IQueryable<PedidoEntity> query, PedidoEntityFilter filtro)
    {
       


        if (filtro.IdPedido.HasValue)
        {
            query = query.Where(pedido => pedido.Id == filtro.IdPedido.Value);
        }

        return query;
    }
}
