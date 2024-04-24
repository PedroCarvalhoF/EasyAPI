using Api.Domain.Entities;
using Api.Domain.Entities.Pedido;
using Domain.Entities.Produto;
using Domain.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ItensPedido
{
    public class ItemPedidoEntity : BaseEntity
    {
        [Required]
        public Guid ProdutoEntityId { get; set; }
        public ProdutoEntity? ProdutoEntity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quatidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Desconto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTtotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalItem { get; set; }

        [MaxLength(200)]
        public string? ObservacaoItem { get; set; }

        [Required]
        public SituacaoItemPedidoEnum SituacaoItemPedidoEnum { get; set; }

        [Required]
        public Guid PedidoEntityId { get; set; }
        public PedidoEntity? PedidoEntity { get; set; }

        [Required]
        public Guid UsuarioRestroId { get; set; }
    }
}
