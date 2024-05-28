namespace Domain.Dtos.Cotacoes.TaxasCDISELIC
{
    public class TaxasDtosHGBrasil
    {
        public string? by { get; set; }
        public bool valid_key { get; set; }
        public List<TaxasDtos>? results { get; set; }
        public double execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}
