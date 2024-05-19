using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PedidoSituacao;
using Domain.Dtos.PontoVendaUser;
using Domain.Entities.PagamentoPedido;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDto : BaseDto
    {
       
        public string? NumeroPedido { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorPedido { get; set; }
        public string? Observacoes { get; set; }
        
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
        public SituacaoPedidoDto? SituacaoPedidoEntity { get; set; }
        public UsuarioPontoVendaDto? UserRegistro { get; set; }
        public PontoVendaDto? PontoVendaEntity { get; set; }
        public IEnumerable<ItemPedidoDto>? ItensPedidoEntities { get; set; }
        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }
    }
}
