using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.ProdutoTipo
{
    public class ProdutoTipoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Habilitado { get; set; }
        [Required]
        [MaxLength(50)]
        public string? DescricaoTipoProduto { get; set; }
    }
}
