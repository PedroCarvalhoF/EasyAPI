using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos.PedidoPagamento
{
    public class PagamentoPedidoDtoUpdate
    {
        [DisplayName("Id do Pedido")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid PedidoEntityId { get; set; }

        [DisplayName("Id Forma de Pagamento")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid FormaPagamentoEntityId { get; set; }

        [DisplayName("Valor Pago")]
        [Required(ErrorMessage = "Informe o {0}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPago { get; set; }
    }
}
