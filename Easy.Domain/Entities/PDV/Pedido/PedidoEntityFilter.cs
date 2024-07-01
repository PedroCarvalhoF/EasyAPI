namespace Easy.Domain.Entities.PDV.Pedido;

public class PedidoEntityFilter
{

    public static IQueryable<PedidoEntity> QueryablePedidoEntity(IQueryable<PedidoEntity> query, PedidoEntityFilter pedidoFitro)
    {
        return query;
    }
}
