namespace Easy.Services.CQRS.PDV.Pdv.Commands;

public class PontoVendaAberturaCommand : BaseCommandsForUpdate
{
    public Guid UsuarioGerentePdvId { get; set; }
    public Guid UsuarioPdvId { get; set; }
    public Guid PeriodoPdvId { get; set; }
}
