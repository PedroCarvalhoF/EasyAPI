using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pedidos
{
    public class PedidoDtoCancelar
    {
        [Required(ErrorMessage = "Informe o Id do Pedido")]
        public Guid IdPedido { get; set; }

        [MinLength(20, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("Motivo do Cancelamento")]
        public string? MotivoCancelamento { get; set; }

    }
}
