using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.ProdutoTipo
{
    public class ProdutoTipoDtoCreate
    {
        [Required]
        [MaxLength(50)]
        public string? DescricaoTipoProduto { get; set; }
    }
}
