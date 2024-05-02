using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PedidoSituacao
{
    public class SituacaoPedidoDtoUpdate
    {
        [Display(Name = "Id Situação")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid Id { get; set; }


        [Display(Name = "Situação do pedido")]
        [Required(ErrorMessage = "Informe a {0}")]
        [MaxLength(80, ErrorMessage = "Quantidae de caracteres deve ser menor ou igual {0}")]
        public string? DescricaoSituacao { get; set; }


        [Display(Name = "Habilitado")]
        [Required(ErrorMessage = "Informe se está habilitado ou não.")]
        public bool Habilitado { get; set; }
    }
}
