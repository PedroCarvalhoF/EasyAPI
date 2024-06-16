using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoCreate
    {
        [Required]
        public Guid ProdutoEntityId { get; set; }
        [Required]
        public Guid CategoriaPrecoEntityId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoProduto { get; set; }
    }
}