using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.ProdutoDtos
{
    public class ProdutoDtoCreate
    {
        [Required]
        public string? NomeProduto { get; set; }

        [Required]
        public string? CodigoBarrasPersonalizado { get; set; }
        public string? Descricao { get; set; }

        public string? Observacoes { get; set; }

        [Required]
        public Guid? CategoriaProdutoEntityId { get; set; }

        [Required]
        public Guid ProdutoMedidaEntityId { get; set; }

        [Required]
        public Guid ProdutoTipoEntityId { get; set; }
        public string? ImgUrl { get; set; }
    }
}
