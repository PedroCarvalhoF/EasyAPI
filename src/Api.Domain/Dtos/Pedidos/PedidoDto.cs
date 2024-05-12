using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PedidoSituacao;
using Domain.Entities.PagamentoPedido;
using Domain.Identity.UserIdentity;

namespace Api.Domain.Dtos.PedidoDtos
{
    public class PedidoDto : BaseDto
    {
        public string? NumeroPedido { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorPedido { get; set; }

        // public Guid SituacaoPedidoId { get; set; }
        // public Guid UserCreatePedidoId { get; set; }
        // public Guid? PontoVendaEntityId { get; set; }
        public string? Observacoes { get; set; }
        public SituacaoPedidoDto? SituacaoPedidoEntity { get; set; }
        public User? UserCreatePedido { get; set; }
        public PontoVendaDto? PontoVendaEntity { get; set; }
        public IEnumerable<ItemPedidoDto>? ItensPedidoEntities { get; set; }

        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }
    }
}
