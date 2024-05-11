using Api.Domain.Entities;
using Api.Domain.Entities.Pedido;
using Domain.Entities.FormaPagamento;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.PagamentoPedido
{
    public class PagamentoPedidoEntity : BaseEntity
    {
        [DisplayName("Id do Pedido")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid PedidoEntityId { get; set; }
        public PedidoEntity? PedidoEntity { get; set; }
        //#################################################

        [DisplayName("Id  Forma de Pagamento")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid FormaPagamentoEntityId { get; set; }
        public FormaPagamentoEntity? FormaPagamentoEntity { get; set; }
        //#################################################

        [DisplayName("Valor Pago")]
        [Required(ErrorMessage = "Informe o {0}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPago { get; set; }
        //#################################################

    }
}
