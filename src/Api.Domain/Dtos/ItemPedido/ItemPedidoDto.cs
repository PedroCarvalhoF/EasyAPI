using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Enuns;

namespace Domain.Dtos.ItemPedido
{
    public class ItemPedidoDto
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public ProdutoDto? ProdutoEntity { get; set; }
        public decimal Quatidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public decimal SubTtotal { get; set; }
        public decimal TotalItem { get; set; }
        public string? ObservacaoItem { get; set; }
        public SituacaoItemPedidoEnum SituacaoItemPedidoEnum { get; set; }
        public PedidoDto? PedidoEntity { get; set; }

        public Guid UsuarioRestroId { get; set; }
    }
}
