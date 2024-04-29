using Api.Domain.Entities;
using Api.Domain.Entities.Pedido;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pedido
{
    public class SituacaoPedidoEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string? DescricaoSituacaoPedido { get; set; }
        public IEnumerable<PedidoEntity>? PedidoEntities { get; set; }
    }
}