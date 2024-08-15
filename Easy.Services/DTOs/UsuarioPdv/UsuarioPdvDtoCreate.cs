namespace Easy.Services.DTOs.UsuarioPdv;

public class UsuarioPdvDtoCreate
{
    public Guid UserPdvId { get; private set; }

    public UsuarioPdvDtoCreate(Guid userPdvId)
    {
        UserPdvId = userPdvId;
    }
}
