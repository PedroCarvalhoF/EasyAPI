using Api.Domain.Entities.PrecoProduto;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.CategoriaPreco
{
    public class CategoriaPrecoEntity : BaseEntity
    {

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Categoria de Preço")]

        [MaxLength(80, ErrorMessage = "Quantidae de caracteres deve ser menor ou igual 80")]
        public string? DescricaoCategoria { get; set; }
        public IEnumerable<PrecoProdutoEntity>? PrecoProdutoEntities { get; set; }

    }
}
