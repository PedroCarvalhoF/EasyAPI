using Api.Domain.Entities;
using Domain.Entities.PagamentoPedido;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.FormaPagamento
{
    public class FormaPagamentoEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string? DescricaoFormaPg { get; set; }
        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }
    }
}
