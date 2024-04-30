namespace Domain.Models.PeriodoPontoVenda
{
    public class PeriodoPontoVendaModel
    {
        public Guid? Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoPeriodo { get; set; }
    }
}
