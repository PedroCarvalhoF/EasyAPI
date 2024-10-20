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
    public virtual ICollection<PedidoEntity>? Pedidos { get; set; }
    public bool Validada => Validar();

    #region Campos Auxiliares/Helpers
    public int QtdPedidos => CalcularQuantidadePedidos();
    public int QuantidadePedidosValidos => CalcularQuantidadePedidosValidos();
    public int QuantidadePedidosCancelados => CalcularQuantidadePedidosCancelados();
    public decimal SomaValorTotalPedidos => CalcularSomaValorTotalPedidos();
    public decimal SomaValorTotalPedidosValidos => CalcularSomaValorTotalPedidosValidos();
    public decimal SomaValorTotalPedidosCancelados => CalcularSomaValorTotalPedidosCancelados();
    public decimal SomaDescontoPedidosValidos => CalcularSomaDescontoPedidosValidos();
    public decimal TicketMedio => CalcularTicketMedio();     

    #endregion
    #region Construtores    
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

    #endregion
    #region Auxiliares
    public static PontoVendaEntity Create(Guid usuarioGerentePdvId, Guid usuarioPdvId, Guid periodoPdvId, FiltroBase user)
       => new PontoVendaEntity(usuarioGerentePdvId, usuarioPdvId, periodoPdvId, user);

    #endregion
    #region Validacoes
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
    #endregion
    #region Metodos

    #region Metodos Pedidos  
    private int CalcularQuantidadePedidos()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Count;
    }
    private int CalcularQuantidadePedidosValidos()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Count(p => !p.Cancelado && p.Finalizado);
    }
    private int CalcularQuantidadePedidosCancelados()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Count(p => p.Cancelado && p.Finalizado);
    }
    private decimal CalcularSomaValorTotalPedidos()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Sum(p => p.Total);
    }
    private decimal CalcularSomaValorTotalPedidosValidos()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Where(p => p.Finalizado && !p.Cancelado).Sum(p => p.Total);
    }
    private decimal CalcularSomaValorTotalPedidosCancelados()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Where(p => p.Finalizado && p.Cancelado).Sum(p => p.Total);
    }
    private decimal CalcularTicketMedio()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return SomaValorTotalPedidosValidos / QuantidadePedidosValidos;
    }
    private decimal CalcularSomaDescontoPedidosValidos()
    {
        if (Pedidos == null || Pedidos.Count == 0)
            return 0;

        return Pedidos.Where(p => p.Finalizado && !p.Cancelado).Sum(p => p.Desconto);
    }
    #endregion
    public void EncerrarPontoVenda()
    {
        if (!Aberto)
            throw new ArgumentException("Ponto de venda já está encerrado");

        Aberto = false;
        UpdateAt = DateTime.Now;
    }
    #endregion
}