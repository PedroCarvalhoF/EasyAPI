using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PagamentoPedidoDtos
{
    public class PagamentoPedidoDtoCreate
    {
        [Required]
        public Guid PedidoEntityId { get; set; }
        [Required]
        public Guid FormaPagamentoEntityId { get; set; }
        [Required]
        public decimal ValorPago { get; set; }
    }
}
