namespace Easy.Services.DTOs.PrecoProduto;

public class PrecoProdutoDtoView
{
    public Guid IdProduto { get; private set; }
    public string CodigoProduto { get; private set; }
    public string NomeProduto { get; private set; }
    public Guid IdCategoria { get; private set; }
    public string CategoriaProduto { get; private set; }
    public Guid IdCategoriaPreco { get; private set; }
    public string CategoriaPreco { get; private set; }
    public decimal Preco { get; private set; }

    public PrecoProdutoDtoView(Guid idProduto, string codigoProduto, string nomeProduto, Guid idCategoria, string categoriaProduto, Guid idCategoriaPreco, string categoriaPreco, decimal preco)
    {
        IdProduto = idProduto;
        CodigoProduto = codigoProduto;
        NomeProduto = nomeProduto;
        IdCategoria = idCategoria;
        CategoriaProduto = categoriaProduto;
        IdCategoriaPreco = idCategoriaPreco;
        CategoriaPreco = categoriaPreco;
        Preco = preco;
    }
}
