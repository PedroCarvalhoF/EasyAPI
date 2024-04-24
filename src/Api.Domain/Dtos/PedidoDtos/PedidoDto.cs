using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Enuns;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? NumeroPedido { get; set; }
        public decimal? TotalItensPedido { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorPedido { get; set; }
        public SituacaoPedidoEnum SituacaoPedidoEnum { get; set; }
        public string? Observacoes { get; set; }
        public Guid UserIdCreatePedido { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public Guid? PontoVendaEntityId { get; set; }
        public PontoVendaDto? PontoVendaEntity { get; set; }
        public IEnumerable<ItemPedidoDto>? ItemPedidoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }

        public IEnumerable<PagamentoPedidoDto>? PagamentoPedidoEntity { get; set; }
    }
}
