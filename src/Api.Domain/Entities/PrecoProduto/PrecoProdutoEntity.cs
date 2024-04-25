using Api.Domain.Entities.CategoriaPreco;
using Domain.Entities.Produto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities.PrecoProduto
{
    public class PrecoProdutoEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Codigo do Produto")]
        public Guid ProdutoEntityId { get; set; }
        public ProdutoEntity? ProdutoEntity { get; set; }


        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Categoria de Produto")]
        public Guid CategoriaPrecoEntityId { get; set; }
        public CategoriaPrecoEntity? CategoriaPrecoEntity { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Preço do Produto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoProduto { get; set; }

    }
}