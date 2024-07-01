using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Entities.PDV.ItensPedido;

public class ItemPedidoEntity : BaseEntity
{
    public decimal Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal DescontoItem { get; set; }
    public decimal SubTotalItem { get; set; }
    public decimal TotalItem { get; set; }
    public bool Cancelado { get; set; }
    public Guid ProdutoId { get; set; }
    public ProdutoEntity? Produto { get; set; }
    public PedidoEntity? Pedido { get; set; }
}
