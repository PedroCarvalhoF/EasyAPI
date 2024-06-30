using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Entities.User;

namespace Easy.Domain.Entities.PDV.UserPDV;

public class UsuarioPdvEntity : BaseEntity
{
    public Guid UserPdvId { get; private set; }
    public virtual UserEntity UserPdv { get; private set; }
    public virtual ICollection<PontoVendaEntity>? UsuariosGerentesPdvs { get; set; }
    public virtual ICollection<PontoVendaEntity>? UsuariosPdvs { get; set; }
    public bool Validada => Validar();
    public UsuarioPdvEntity() { }
    UsuarioPdvEntity(Guid userPdvId, FiltroBase users) : base(users)
    {
        if (userPdvId == Guid.Empty)
            throw new ArgumentException("Informe o id do usuário");
        UserPdvId = userPdvId;
        Id = userPdvId;
    }
    private bool Validar()
    {
        if (UserPdvId == Guid.Empty)
            return false;

        return true;
    }

    public static UsuarioPdvEntity Create(Guid userPdvId, FiltroBase user)
        => new UsuarioPdvEntity(userPdvId, user);

    public void Desabilitar()
    {
        Habilitado = false;
        UpdateAt = DateTime.UtcNow;
    }

    public void Habilitar()
    {
        Habilitado = true;
        UpdateAt = DateTime.UtcNow;
    }
}
