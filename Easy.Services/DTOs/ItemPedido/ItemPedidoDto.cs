namespace Easy.Services.DTOs.ItemPedido;

public class ItemPedidoDto
{
    public Guid IdItem { get; private set; }
    public DateTime CreateAt { get; private set; }
    public Guid ProdutoId { get; private set; }
    public string NomeProduto { get; private set; }
    public string CodigoProduto { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal Preco { get; private set; }
    public decimal DescontoItem { get; private set; }
    public decimal SubTotalItem { get; private set; }
    public decimal TotalItem { get; private set; }
    public bool Cancelado { get; private set; }
    public Guid PedidoId { get; private set; }
    public string NumeroPedido { get; private set; }

    public ItemPedidoDto(Guid idItem, DateTime createAt, Guid produtoId, string nomeProduto, string codigoProduto, decimal quantidade, decimal preco, decimal descontoItem, decimal subTotalItem, decimal totalItem, bool cancelado, Guid pedidoId, string numeroPedido)
    {
        IdItem = idItem;
        CreateAt = createAt;
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        CodigoProduto = codigoProduto;
        Quantidade = quantidade;
        Preco = preco;
        DescontoItem = descontoItem;
        SubTotalItem = subTotalItem;
        TotalItem = totalItem;
        Cancelado = cancelado;
        PedidoId = pedidoId;
        NumeroPedido = numeroPedido;
    }
}
