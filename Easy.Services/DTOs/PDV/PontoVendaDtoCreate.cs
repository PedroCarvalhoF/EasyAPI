namespace Easy.Services.DTOs.PDV;

public class PontoVendaDtoCreate
{
    public Guid UsuarioGerentePdvId { get; private set; }
    public Guid UsuarioPdvId { get; private set; }
    public Guid PeriodoPdvId { get; private set; }
}
