namespace Easy.Services.DTOs.PeriodoPdv;

public class PeriodoPdvDtoRequestId
{
    public Guid IdPeriodo { get; set; }

    public PeriodoPdvDtoRequestId(Guid idPeriodo)
    {
        IdPeriodo = idPeriodo;
    }
}
