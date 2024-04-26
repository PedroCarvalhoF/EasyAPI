using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Enuns;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDtoUpdateResult
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
        public PontoVendaEntity? PontoVendaEntity { get; set; }
        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntity { get; set; }
        public CategoriaPrecoDto? CategoriaPrecoEntity { get; set; }
    }
}
