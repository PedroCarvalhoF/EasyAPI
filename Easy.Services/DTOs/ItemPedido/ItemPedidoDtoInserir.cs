namespace Easy.Services.DTOs.ItemPedido;

public class ItemPedidoDtoInserir
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal Preco { get; private set; }
    public ItemPedidoDtoInserir(Guid pedidoId, Guid produtoId, decimal quantidade, decimal preco)
    {
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
    }
}
