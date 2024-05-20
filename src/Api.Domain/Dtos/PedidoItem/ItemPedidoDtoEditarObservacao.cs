using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PedidoItem
{
    public class ItemPedidoDtoEditarObservacao
    {
        [DisplayName("Id do item do pedido")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid Id { get; set; }

        [DisplayName("Observacao Item Pedido")]
        [Required(ErrorMessage = "Informe o {0}")]
        public string? ObservacaoItem { get; set; }
    }
}
