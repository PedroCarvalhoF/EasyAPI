using Api.Domain.Entities.CategoriaPreco;
using Domain.Entities.Produto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities.PrecoProduto
{
    public class PrecoProdutoEntity : BaseEntity
    {
        [Required]
        public Guid ProdutoEntityId { get; set; }
        public ProdutoEntity? ProdutoEntity { get; set; }

        [Required]
        public Guid CategoriaPrecoEntityId { get; set; }
        public CategoriaPrecoEntity? CategoriaPrecoEntity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecoProduto { get; set; }

    }
}