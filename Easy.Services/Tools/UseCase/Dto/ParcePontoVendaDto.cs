using Easy.Domain.Entities.PDV.PDV;
using Easy.Services.DTOs.PDV;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PontoVendaDto ParcePontoVendaDto(PontoVendaEntity pdv)
        {
            return new PontoVendaDto(
                pdv.Id,
                pdv.UsuarioGerentePdvId,
                pdv.UsuarioGerentePdv!.UserPdv!.Nome,
                pdv.UsuarioPdvId,
                pdv.UsuarioPdv!.UserPdv!.Nome,
                pdv.Aberto,
                pdv.PeriodoPdvId,
                pdv.PeriodoPdv!.DescricaoPeriodo,
                pdv.CreateAt,
                pdv.QtdPedidos,
                pdv.QuantidadePedidosValidos,
                pdv.QuantidadePedidosCancelados,
                pdv.SomaValorTotalPedidos,
                pdv.SomaValorTotalPedidosValidos,
                pdv.SomaValorTotalPedidosCancelados,
                pdv.TicketMedio,
                pdv.SomaDescontoPedidosValidos);
        }

        public static IEnumerable<PontoVendaDto> ParcePontosVendasDtos(IEnumerable<PontoVendaEntity> pdvEntities)
        {
            foreach (var pdv in pdvEntities)
            {
                yield return ParcePontoVendaDto(pdv);
            }
        }
    }
}
