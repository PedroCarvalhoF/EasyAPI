using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.ItemPedido;
using Domain.Dtos.PedidoSituacao;
using Domain.Dtos.PerfilUsuario;
using Domain.Entities.PagamentoPedido;

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
        public PerfilUsuarioDto? UserCreatePedido { get; set; }
        public PontoVendaDto? PontoVendaEntity { get; set; }
        public IEnumerable<ItemPedidoDto>? ItensPedidoEntities { get; set; }

        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }
    }
}
