using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDtoCreate
    {
        public string? NumeroPedido { get; set; }

        public string? Observacoes { get; set; }

        [Required]
        public Guid UserIdCreatePedido { get; set; }

        [Required]
        public Guid PontoVendaEntityId { get; set; }

        [Required]
        public Guid CategoriaPrecoEntityId { get; set; }
    }
}
