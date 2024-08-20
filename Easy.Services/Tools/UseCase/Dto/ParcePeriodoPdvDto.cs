using Easy.Domain.Entities.PDV.Periodo;
using Easy.Services.DTOs.PeriodoPdv;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PeriodoPdvDto ParcePeriodoPdvDto(PeriodoPdvEntity pr)
        {
            return new PeriodoPdvDto(pr.Id, pr.DescricaoPeriodo, pr.Habilitado);
        }
        public static IEnumerable<PeriodoPdvDto> ParcePeriodoPdvDto(IEnumerable<PeriodoPdvEntity> periodos)
        {
            foreach (var pr in periodos)
            {
                yield return ParcePeriodoPdvDto(pr);
            }
        }
    }
}
