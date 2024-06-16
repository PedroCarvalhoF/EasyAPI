using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProdutoEntityId { get; set; }
        [Required]
        public Guid CategoriaPrecoEntityId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoProduto { get; set; }
        [Required]
        public bool Habilitado { get; set; }

    }
}