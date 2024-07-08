namespace Easy.Services.CQRS.PDV.PrecoProduto.Commands;

public class PrecoProdutoCommand : BaseCommandsForUpdate
{
    public Guid ProdutoEntityId { get; set; }
    public Guid CategoriaPrecoEntityId { get; set; }
    public decimal Preco { get; set; }
}
