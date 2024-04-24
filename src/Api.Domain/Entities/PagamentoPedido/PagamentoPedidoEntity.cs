using Api.Domain.Entities;
using Api.Domain.Entities.Pedido;
using Domain.Entities.FormaPagamento;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.PagamentoPedido
{
    public class PagamentoPedidoEntity : BaseEntity
    {
        [Required]
        public Guid PedidoEntityId { get; set; }
        public PedidoEntity? PedidoEntity { get; set; }
        [Required]
        public Guid FormaPagamentoEntityId { get; set; }
        public FormaPagamentoEntity? FormaPagamentoEntity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPago { get; set; }
    }
}
