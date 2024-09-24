using Easy.Domain.Entities.PDV.PDV;
using Easy.Services.DTOs.PDV;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PontoVendaDto ParcePontoVendaDto(PontoVendaEntity pdvEntity)
        {
            return new PontoVendaDto(
                pdvEntity.Id,
                pdvEntity.UsuarioGerentePdvId,
                pdvEntity.UsuarioGerentePdv.UserPdv.Nome,
                pdvEntity.UsuarioPdvId,
                pdvEntity.UsuarioPdv.UserPdv.Nome,
                pdvEntity.Aberto,
                pdvEntity.PeriodoPdvId,
                pdvEntity.PeriodoPdv.DescricaoPeriodo, pdvEntity.CreateAt,
                pdvEntity.QtdPedidos);
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
