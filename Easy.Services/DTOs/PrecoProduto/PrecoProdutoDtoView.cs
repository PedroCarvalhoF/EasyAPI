using Easy.Domain.Entities.PDV.PrecoProduto;

namespace Easy.Services.DTOs.PrecoProduto;

public class PrecoProdutoDtoView
{
    public Guid IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public Guid IdCategoriaPreco { get; set; }
    public string CategoriaPreco { get; set; }
    public decimal Preco { get; set; }
}
