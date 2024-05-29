using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pedidos
{
    public class PedidoDtoCancelar
    {
        [Required(ErrorMessage = "Informe o Id do Pedido")]
        public Guid IdPedido { get; set; }

        [MinLength(25, ErrorMessage = "Descreva um pouco mais sobre o cancelamento")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("Motivo do Cancelamento")]
        [Required(ErrorMessage = "Informe o motivo do cancelamento")]
        public string? MotivoCancelamento { get; set; }

    }
}
