namespace Easy.Services.DTOs.PDV;

public class PontoVendaDtoCreate
{    
    public Guid UsuarioPdvId { get; private set; }
    public Guid PeriodoPdvId { get; private set; }
    public PontoVendaDtoCreate(Guid usuarioGerentePdvId, Guid usuarioPdvId, Guid periodoPdvId)
    {        
        UsuarioPdvId = usuarioPdvId;
        PeriodoPdvId = periodoPdvId;
    }
}
