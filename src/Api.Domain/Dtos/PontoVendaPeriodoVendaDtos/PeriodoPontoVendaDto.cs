using Api.Domain.Dtos;

namespace Domain.Dtos.PontoVendaPeriodoVendaDtos
{
    public class PeriodoPontoVendaDto : BaseDto
    {
        public bool Habilitado { get; set; }
        public string? DescricaoPeriodo { get; set; }
    }
}
