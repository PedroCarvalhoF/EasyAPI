namespace Easy.Services.CQRS.PDV.PrecoProduto.Commands;

public class PrecoProdutoCommand : BaseCommands
{
    public Guid ProdutoEntityId { get;  set; }
    public Guid CategoriaPrecoEntityId { get; set; }
    public decimal Preco { get;  set; }
}
