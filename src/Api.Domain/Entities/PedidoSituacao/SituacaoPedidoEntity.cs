using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PedidoSituacao
{
    public class SituacaoPedidoEntity : BaseEntity
    {
        [Display(Name = "Situação do pedido")]
        [Required(ErrorMessage = "Informe a {0}")]
        [MaxLength(80, ErrorMessage = "Quantidae de caracteres deve ser menor ou igual {0}")]
        public string? DescricaoSituacao { get; set; }
    }
}
