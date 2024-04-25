namespace Domain.Dtos.PontoVendaPeriodoVendaDtos
{
    public class PeriodoPontoVendaDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoPeriodo { get; set; }
    }
}
