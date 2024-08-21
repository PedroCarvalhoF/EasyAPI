using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.UsuarioPdv;

public class UsuarioPdvDtoCreate
{
    [Required]
    public Guid UserPdvId { get; private set; }

    public UsuarioPdvDtoCreate(Guid userPdvId)
    {
        UserPdvId = userPdvId;
    }
}
