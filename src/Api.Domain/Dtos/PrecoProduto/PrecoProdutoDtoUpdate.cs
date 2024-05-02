using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProdutoId { get; set; }
        [Required]
        public Guid CategoriaPrecoId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecoProduto { get; set; }

    }
}