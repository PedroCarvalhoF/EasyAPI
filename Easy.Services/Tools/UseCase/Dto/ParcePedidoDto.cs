using Easy.Domain.Entities.PDV.Pedido;
using Easy.Services.DTOs.Pedido;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PedidoDto ParcePedidoDto(PedidoEntity ped)
        {
            return new PedidoDto(
                ped.Id,
                ped.TipoPedido,
                ped.NumeroPedido,
                ped.Desconto,
                ped.SubTotal,
                ped.Total, 
                ped.Observacoes,
                ped.Cancelado,
                ped.PontoVendaEntityId,
                ped.CategoriaPrecoId,
                ped.CategoriaPreco!.DescricaoCategoriaPreco, 
                ped.UserId, ped.CreateAt, ped.Finalizado);
        }

        public static IEnumerable<PedidoDto> ParcePedidoDto(IEnumerable<PedidoEntity> pedidos)
        {
            foreach (var pedido in pedidos)
            {
                yield return ParcePedidoDto(pedido);
            }
        }
    }
}
