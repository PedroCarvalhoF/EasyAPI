namespace Easy.Services.DTOs.PrecoProduto;

public class PrecoProdutoDtoCreate
{    
    public Guid ProdutoEntityId { get; private set; }
    public Guid CategoriaPrecoEntityId { get; private set; }
    public decimal Preco { get; private set; }
    public PrecoProdutoDtoCreate(Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco)
    {
        ProdutoEntityId = produtoEntityId;
        CategoriaPrecoEntityId = categoriaPrecoEntityId;
        Preco = preco;
    }
}
