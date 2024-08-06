namespace Easy.Services.DTOs.PrecoProduto;

public class PrecoProdutoDtoCreate
{
    public Guid ProdutoEntityId { get; set; }
    public Guid CategoriaPrecoEntityId { get; set; }
    public decimal Preco { get; set; }
}
