using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDtoUpdate
    {
        [Required]
        public string? NumeroPedido { get; set; }
        [Required]
        public decimal? TotalItensPedido { get; set; }
        [Required]
        public decimal? ValorDesconto { get; set; }
        [Required]
        public decimal? ValorPedido { get; set; }
        [Required]
        public bool Cancelado { get; set; }
        [Required]
        public bool AbertoEncerrado { get; set; }

        [MaxLength(200)]
        public string? Observacoes { get; set; }

        [Required]
        /// <summary>
        /// Usuário que gerou o pedido
        /// </summary>
        public Guid UserIdCreatePedido { get; set; }
        [Required]
        public DateTime DataUltimaAtualizacao { get; set; }

        [Required]
        public Guid CategoriaPrecoEntityId { get; set; }

    }
}
