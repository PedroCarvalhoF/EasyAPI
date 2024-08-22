namespace Easy.Services.DTOs.PDV
{
    public class PontoVendaDto
    {
        public Guid Id { get; private set; }
        public DateTime DataHoraAbertura { get; private set; }
        public Guid UsuarioGerentePdvId { get; private set; }
        public string UsuarioGerenteNome { get; private set; }
        public Guid UsuarioPdvId { get; private set; }
        public string UsuarioPdvNome { get; private set; }
        public bool Aberto { get; private set; }
        public Guid PeriodoPdvId { get; private set; }
        public string PeriodoDescricao { get; private set; }
        public PontoVendaDto(Guid id, Guid usuarioGerentePdvId, string usuarioGerenteNome, Guid usuarioPdvId, string usuarioPdvNome, bool aberto, Guid periodoPdvId, string periodoDescricao, DateTime dataHoraAbertura)
        {
            Id = id;
            UsuarioGerentePdvId = usuarioGerentePdvId;
            UsuarioGerenteNome = usuarioGerenteNome;
            UsuarioPdvId = usuarioPdvId;
            UsuarioPdvNome = usuarioPdvNome;
            Aberto = aberto;
            PeriodoPdvId = periodoPdvId;
            PeriodoDescricao = periodoDescricao;
            DataHoraAbertura = dataHoraAbertura;
        }
    }
}
