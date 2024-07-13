using Easy.Domain.Enuns;
using Easy.Services.DTOs.CategoriaProduto;

namespace Easy.Services.DTOs.Produto;

public class ProdutoDto
{
    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string? DescricaoCategoria { get; set; }
    public string? NomeProduto { get;  set; }
    public string? Codigo { get;  set; }
    public string? Descricao { get;  set; }
    public string? Observacoes { get;  set; }
    public string? ImagemUrl { get;  set; }    
    public virtual CategoriaProdutoDto? CategoriaProdutoEntity { get; set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get;  set; }
    public ProdutoTipoEnum TipoProdutoEnum { get;  set; }
}
