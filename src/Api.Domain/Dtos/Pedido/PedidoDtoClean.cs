using Api.Domain.Dtos;
using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos.PedidoSituacao;

namespace Domain.Dtos.Pedido
{
    public class PedidoDtoClean: BaseDto
    {       
        public string? NumeroPedido { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorPedido { get; set; }
        public string? Observacoes { get; set; }
        public SituacaoPedidoDto? SituacaoPedidoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
    }
}
