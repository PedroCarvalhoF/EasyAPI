namespace Easy.Services.DTOs.PrecoProduto;
public class PrecoProdutoDto
{
    public Guid Id { get; private set; }
    public Guid PrecoProdutoId { get; private set; }
    public bool PrecoHabilitado { get; private set; }
    public Guid ProdutoId { get; private set; }
    public string CodigoProduto { get; private set; }
    public string NomeProduto { get; private set; }
    public decimal Preco { get; private set; }
    public Guid CategoriaPrecoId { get; private set; }
    public string DescricaoCategoriaPreco { get; private set; }
    public PrecoProdutoDto(Guid id, Guid precoProdutoId, bool precoHabilitado, Guid produtoId, string codigoProduto, string nomeProduto, decimal preco, Guid categoriaPrecoId, string descricaoCategoriaPreco)
    {
        PrecoProdutoId = precoProdutoId;
        PrecoHabilitado = precoHabilitado;
        ProdutoId = produtoId;
        CodigoProduto = codigoProduto;
        NomeProduto = nomeProduto;
        Preco = preco;
        CategoriaPrecoId = categoriaPrecoId;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
        Id = id;
    }
}
