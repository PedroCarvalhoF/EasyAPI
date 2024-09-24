
namespace Easy.Domain.Entities.PDV.ItensPedido
{
    public class ItemPedidoEntityFilter
    {
        public Guid? IdItem { get; set; }
        public List<Guid>? IdsItens { get; set; }
        public Guid? PedidoId { get; set; }
        public Guid? ProdutoId { get; set; }

        public static IQueryable<ItemPedidoEntity> QueryablePedidoEntity(IQueryable<ItemPedidoEntity> query, ItemPedidoEntityFilter filtro)
        {

            if (filtro.IdItem != null && filtro.IdItem != Guid.Empty)
            {
                query = query.Where(item => item.Id == filtro.IdItem);
            }

            if (filtro.IdsItens != null && filtro.IdsItens.Any())
            {
                query = query.Where(item => filtro.IdsItens.Contains(item.Id));
            }

            if (filtro.PedidoId != null && filtro.PedidoId != Guid.Empty)
            {
                query = query.Where(item => item.PedidoId == filtro.PedidoId);
            }

            if (filtro.ProdutoId != null && filtro.ProdutoId != Guid.Empty)
            {
                query = query.Where(item => item.ProdutoId == filtro.ProdutoId);
            }

            return query;
        }
    }
}
