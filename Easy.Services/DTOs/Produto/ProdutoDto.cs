namespace Easy.Services.DTOs.Produto;

public class ProdutoDto
{
    public Guid ProdutoId { get; private set; }
    public string NomeProduto { get; private set; }
    public string Codigo { get; private set; }
    public bool Habilitado { get; private set; }
    public string ImagemUrl { get; private set; }
    public int MedidaProdutoEnum { get; private set; }
    public int TipoProdutoEnum { get; private set; }
    public Guid CategoriaId { get; private set; }
    public string DescricaoCategoria { get; private set; }
    public ProdutoDto(Guid produtoId, string nomeProduto, string codigo, string imagemUrl, int medidaProdutoEnum, int tipoProdutoEnum, Guid categoriaId, string descricaoCategoria, bool habilitado)
    {
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Codigo = codigo;
        ImagemUrl = imagemUrl;
        MedidaProdutoEnum = medidaProdutoEnum;
        TipoProdutoEnum = tipoProdutoEnum;
        CategoriaId = categoriaId;
        DescricaoCategoria = descricaoCategoria;
        Habilitado = habilitado;
    }
}
