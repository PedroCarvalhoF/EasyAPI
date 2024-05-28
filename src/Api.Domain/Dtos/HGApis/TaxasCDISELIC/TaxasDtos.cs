namespace Domain.Dtos.Cotacoes.TaxasCDISELIC
{
    public class TaxasDtos
    {
        public string date { get; set; }
        public double cdi { get; set; }
        public double selic { get; set; }
        public double daily_factor { get; set; }
        public double selic_daily { get; set; }
        public double cdi_daily { get; set; }
    }
}
