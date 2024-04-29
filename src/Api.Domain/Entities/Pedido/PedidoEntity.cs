using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.Pedido;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities.Pedido
{
    public class PedidoEntity : BaseEntity
    {
        [Required]
        public string? NumeroPedido { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalItensPedido { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorDesconto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorPedido { get; set; }

        [Required]
        public Guid? SituacaoPedidoEntityId { get; set; }
        public SituacaoPedidoEntity? SituacaoPedidoEntity { get; set; }

        [MaxLength(200)]
        public string? Observacoes { get; set; }

        [Required]
        public Guid UserIdCreatePedido { get; set; }
        [Required]
        public DateTime DataUltimaAtualizacao { get; set; }


        //um pedido contem 1 pdv
        [Required]
        public Guid? PontoVendaEntityId { get; set; }
        public PontoVendaEntity? PontoVendaEntity { get; set; }

        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntities { get; set; }

        [Required]
        public Guid? CategoriaPrecoEntityId { get; set; }
        public CategoriaPrecoEntity? CategoriaPrecoEntity { get; set; }

        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }
    }
}
