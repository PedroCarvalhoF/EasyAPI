using Easy.Domain.Entities.PDV.UserPDV;
namespace Easy.Domain.Entities.PDV.PDV;

public class PontoVendaEntity : BaseEntity
{
    public Guid UsuarioGerentePdvId { get; set; }
    public virtual UsuarioPdvEntity? UsuarioGerentePdv { get; set; }
    public Guid UsuarioPdvid { get; set; }
    public virtual UsuarioPdvEntity? UsuarioPdv { get; set; }
    public bool Aberto { get; set; }
}
