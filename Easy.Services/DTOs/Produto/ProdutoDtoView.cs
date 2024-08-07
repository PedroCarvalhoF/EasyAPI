namespace Easy.Services.DTOs.Produto;

public class ProdutoDtoView
{
    public Guid Id { get; set; }
    public string? NomeProduto { get; set; }
    public string? Codigo { get; set; }
    public string? DescricaoCategoria { get; set; }
    public string? Medida { get; set; }
    public string? TipoProduto { get; set; }
}
