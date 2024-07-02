
namespace Easy.Domain.Entities.PDV.ItensPedido
{
    public class ItemPedidoEntityFilter
    {
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal DescontoItem { get; set; }
        public decimal SubTotalItem { get; set; }
        public decimal TotalItem { get; set; }
        public bool Cancelado { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid? PedidoId { get; set; }

        public static IQueryable<ItemPedidoEntity> QueryableItemPedidoEntity(IQueryable<ItemPedidoEntity> query, FiltroBase filtro)
        {
            return query;
        }
    }
}
