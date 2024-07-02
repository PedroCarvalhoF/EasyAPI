using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Tools.Validation;

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
    public Guid? PedidoId { get; set; }
    public PedidoEntity? Pedido { get; set; }
    public bool Validada => Validar();
    private bool Validar()
    {
        if (Quantidade <= 0) return false;
        if (Preco < 0) return false;
        if (ProdutoId == Guid.Empty) return false;
        if (PedidoId == Guid.Empty) return false;

        return true;
    }

    //INSERIR ITEM DO PEDIDO
    public ItemPedidoEntity() { }
    ItemPedidoEntity(decimal quantidade, decimal preco, Guid produtoId, Guid? pedidoId, FiltroBase filtro) : base(filtro)
    {
        DomainValidation.When(quantidade <= 0, "Quantidade não pode ser menor igual a zero.");
        DomainValidation.When(preco < 0, "Preço não pode ser menor zero.");
        DomainValidation.When(produtoId == Guid.Empty, "Informe o id do produto.");
        DomainValidation.When(pedidoId == Guid.Empty, "Informe o id do pedido.");

        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
        PedidoId = pedidoId;
        Cancelado = false;
        DescontoItem = 0;
        CalcularItem();
    }

    public static ItemPedidoEntity InserirItem(decimal quantidade, decimal preco, Guid produtoId, Guid? pedidoId, FiltroBase filtro)
        => new ItemPedidoEntity(quantidade, preco, produtoId, pedidoId, filtro);

    private void CalcularItem()
    {
        SubTotalItem = Quantidade * Preco;
        TotalItem = SubTotalItem - DescontoItem;
        Atualizacao();
    }
    public void AplicarDescontoValorReal(decimal valorDesconto)
    {
        if (valorDesconto <= 0)
            throw new ArgumentException("Valor do desconto não pode ser menor ou igual a zero.");

        if (valorDesconto > SubTotalItem)
            throw new ArgumentException("Valor do desconto não pode ultrapassar o valor do item.");

        DescontoItem = valorDesconto;

        CalcularItem();
    }
    public void AplicarDescontoPedidoPercentual(decimal descontoPercentual)
    {
        if (descontoPercentual <= 0)
            throw new ArgumentException("Percentual do desconto não pode ser menor ou igual a zero.");

        if (descontoPercentual > 100)
            throw new ArgumentException("Percentual do desconto não pode ultrapassar de 100%.");

        decimal valorDescontoReal = SubTotalItem * (descontoPercentual / 100);

        AplicarDescontoValorReal(valorDescontoReal);
    }
    public void RemoverDesconto()
    {
        DescontoItem = 0;
        CalcularItem();
    }
    public void CancelarItem()
    {
        if (Cancelado)
            throw new ArgumentException("Item já está cancelado");
        Cancelado = true;
    }
}
