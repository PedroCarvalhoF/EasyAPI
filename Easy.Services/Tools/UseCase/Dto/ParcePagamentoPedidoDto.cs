using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Services.DTOs.PagamentoPedido;

namespace Easy.Services.Tools.UseCase.Dto;

public partial class DtoMapper
{
    public static PagamentoPedidoDto ParcePagamentoPedidoDto(PagamentoPedidoEntity entity)
    {
        return new PagamentoPedidoDto(entity.Id, entity.FormaPagamento.DescricaFormaPagamento, entity.PedidoId, entity.ValorPago);
    }

    public static IEnumerable<PagamentoPedidoDto> ParcePagamentoPedidoDto(IEnumerable<PagamentoPedidoEntity> entities)
    {
        foreach (var pagamento_entity in entities)
        {
            yield return ParcePagamentoPedidoDto(pagamento_entity);
        }
    }
}
