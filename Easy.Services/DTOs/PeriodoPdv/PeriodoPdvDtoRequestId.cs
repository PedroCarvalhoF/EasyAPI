using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.PeriodoPdv;

public class PeriodoPdvDtoRequestId
{
    [Required]
    public Guid IdPeriodo { get; private set; }

    public PeriodoPdvDtoRequestId(Guid idPeriodo)
    {
        IdPeriodo = idPeriodo;
    }
}
