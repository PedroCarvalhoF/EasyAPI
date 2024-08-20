namespace Easy.Services.DTOs.PeriodoPdv
{
    public class PeriodoPdvDto
    {
        public Guid Id { get; private set; }
        public string DescricaoPeriodo { get; private set; }
        public bool Habilitado { get; private set; }
        public string Info => Detalhes();
        public PeriodoPdvDto(Guid id, string descricaoPeriodo, bool habilitado)
        {
            Id = id;
            DescricaoPeriodo = descricaoPeriodo;
            Habilitado = habilitado;
        }
        private string Detalhes()
        {
            var str = Habilitado ? "habilitado" : "desabilitado";
            return $"Periodo Pdv {str}";
        }
    }
}
