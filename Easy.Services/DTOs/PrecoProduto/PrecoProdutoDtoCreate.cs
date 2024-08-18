using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.Services.DTOs.PrecoProduto;

public class PrecoProdutoDtoCreate
{
    [Required]
    public Guid ProdutoEntityId { get; private set; }
    [Required]
    public Guid CategoriaPrecoEntityId { get; private set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; private set; }
    public PrecoProdutoDtoCreate(Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco)
    {
        ProdutoEntityId = produtoEntityId;
        CategoriaPrecoEntityId = categoriaPrecoEntityId;
        Preco = preco;
    }
}
