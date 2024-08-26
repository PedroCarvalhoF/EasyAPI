using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.Pedido
{
    public class PedidoDtoCreate
    {
        public string? NumeroPedido { get; private set; }
        [Required]
        public Guid PontoVendaId { get; private set; }
        [Required]
        public Guid CategoriaPrecoId { get; private set; }
        public PedidoDtoCreate(string? numeroPedido, Guid pontoVendaId, Guid categoriaPrecoId)
        {
            NumeroPedido = numeroPedido;
            PontoVendaId = pontoVendaId;
            CategoriaPrecoId = categoriaPrecoId;
        }
    }
}
