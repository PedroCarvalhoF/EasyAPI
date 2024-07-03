using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Tools.Validation;
namespace Easy.Domain.Entities.PDV.PDV;

public class PontoVendaEntity : BaseEntity
{
    public Guid UsuarioGerentePdvId { get; set; }
    public virtual UsuarioPdvEntity? UsuarioGerentePdv { get; set; }
    public Guid UsuarioPdvId { get; set; }
    public virtual UsuarioPdvEntity? UsuarioPdv { get; set; }
    public bool Aberto { get; set; }
    public Guid PeriodoPdvId { get; set; }
    public virtual PeriodoPdvEntity? PeriodoPdv { get; set; }
    public virtual ICollection<PedidoEntity> Pedidos { get; set; }
    public bool Validada => Validar();


    public PontoVendaEntity() { }

    PontoVendaEntity(Guid usuarioGerentePdvId, Guid usuarioPdvId, Guid periodoPdvId, FiltroBase user) : base(user)
    {
        DomainValidation.When(usuarioGerentePdvId == Guid.Empty, "Informe o id gerente pdv.");
        DomainValidation.When(usuarioPdvId == Guid.Empty, "Informe o id usuário pdv.");
        DomainValidation.When(periodoPdvId == Guid.Empty, "Informe o id período pdv.");

        UsuarioGerentePdvId = usuarioGerentePdvId;
        UsuarioPdvId = usuarioPdvId;
        PeriodoPdvId = periodoPdvId;
        Aberto = true;
    }

    PontoVendaEntity(Guid id, bool habilitado, Guid usuarioGerentePdvId, Guid usuarioPdvId, bool aberto, Guid periodoPdvId, FiltroBase user) : base(id, habilitado, user)
    {
        DomainValidation.When(id == Guid.Empty, "Informe o id pdv.");
        DomainValidation.When(usuarioGerentePdvId == Guid.Empty, "Informe o id gerente pdv.");
        DomainValidation.When(usuarioPdvId == Guid.Empty, "Informe o id usuário pdv.");
        DomainValidation.When(periodoPdvId == Guid.Empty, "Informe o id período pdv.");

        UsuarioGerentePdvId = usuarioGerentePdvId;
        UsuarioPdvId = usuarioPdvId;
        Aberto = aberto;
        PeriodoPdvId = periodoPdvId;
    }
    private bool Validar()
    {
        if (UsuarioGerentePdvId == Guid.Empty)
            return false;

        if (UsuarioPdvId == Guid.Empty)
            return false;

        if (PeriodoPdvId == Guid.Empty)
            return false;

        return true;
    }

    public static PontoVendaEntity Create(Guid usuarioGerentePdvId, Guid usuarioPdvId, Guid periodoPdvId, FiltroBase user)
        => new PontoVendaEntity(usuarioGerentePdvId, usuarioPdvId, periodoPdvId, user);

    public void EncerrarPontoVenda()
    {
        if (!Aberto)
            throw new ArgumentException("Ponto de venda já está encerrado");

        Aberto = false;
        UpdateAt = DateTime.Now;
    }

}