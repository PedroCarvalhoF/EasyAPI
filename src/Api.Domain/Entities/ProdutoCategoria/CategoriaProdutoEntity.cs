
using Api.Domain.Entities;
using Domain.Entities.Produto;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CategoriaProduto
{
    public class CategoriaProdutoEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        [Display(Name = "Categoria")]
        public string? DescricaoCategoria { get; set; }
        public IEnumerable<ProdutoEntity>? ProdutoEntities { get; set; }

    }
}
