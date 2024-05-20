using Api.Domain.Dtos;
using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PontoVendaUser;
using Domain.Dtos.ProdutoDtos;


namespace Domain.Dtos.ItemPedido
{
    public class ItemPedidoDto : BaseDto
    {
        public ProdutoDto? ProdutoEntity { get; set; }
        public decimal Quatidade { get; set; }
        public decimal Preco { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
        public string? ObservacaoItem { get; set; }
        public UsuarioPontoVendaDto? UsuarioPontoVendaEntity { get; set; }
        public PedidoDto? PedidoEntity { get; set; }
    }
}
