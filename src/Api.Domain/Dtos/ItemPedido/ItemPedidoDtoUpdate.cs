using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.ItemPedido
{
    public class ItemPedidoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProdutoEntityId { get; set; }

        [Required]
        public decimal Quatidade { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public decimal Desconto { get; set; }


        [MaxLength(200)]
        public string? ObservacaoItem { get; set; }

        [Required]
        public Guid PedidoEntityId { get; set; }

        [Required]
        public Guid UsuarioRestroId { get; set; }
    }
}
