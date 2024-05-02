using Api.Domain.Entities;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Entities.ProdutoMedida;
using Domain.Entities.CategoriaProduto;
using Domain.Entities.ProdutoTipo;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Produto
{
    public class ProdutoEntity : BaseEntity
    {


        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Produto")]

        public string? NomeProduto { get; set; }
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Código")]

        public string? CodigoBarrasPersonalizado { get; set; }

        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }


        [Required(ErrorMessage = "Informe a categoria")]
        public Guid? CategoriaProdutoEntityId { get; set; }
        public CategoriaProdutoEntity? CategoriaProdutoEntity { get; set; } //ok


        [Required(ErrorMessage = "Informe o qual tipo de medida")]
        public Guid ProdutoMedidaEntityId { get; set; }
        public ProdutoMedidaEntity? ProdutoMedidaEntity { get; set; } //ok


        [Required(ErrorMessage = "Informe o tipo do produto")]
        public Guid? ProdutoTipoEntityId { get; set; }
        public ProdutoTipoEntity? ProdutoTipoEntity { get; set; } //ok
        public string? ImgUrl { get; set; }

        public IEnumerable<PrecoProdutoEntity>? PrecoProdutoEntities { get; set; }
    }
}
