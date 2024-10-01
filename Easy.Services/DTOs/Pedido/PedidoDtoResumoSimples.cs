namespace Easy.Services.DTOs.Pedido;
public class PedidoDtoResumoSimples
{
    public Guid PdvId { get; private set; }
    public DateTime DataHoraResumoAtualizado = DateTime.Now;
    public int QtdTotalPedidos => QtdTotalPedidosValidos + QtdTotalPedidosCancelados + QtdTotalPedidosPendentes;
    public int QtdTotalPedidosValidos => SomaQtdTotalPedidosValidos();
    public decimal ValorTotalPedidosValidos => SomaValorTotalPedidosValidos();
    public int QtdTotalPedidosCancelados => SomaQtdTotalPedidosCancelados();
    public decimal ValorTotalPedidosCancelados => SomaValorTotalPedidosCancelados();
    public int QtdTotalPedidosPendentes => SomaQtdTotalPedidosPendentes();
    public decimal ValorTotalPedidosPendentes => SomaValorTotalPedidosPendentes();

    #region Soma Valor Pedidos
    private decimal SomaValorTotalPedidosValidos()
    {
        return PedidosValidos.Sum(pedido => pedido.Total) ?? 0;
    }
    private decimal SomaValorTotalPedidosCancelados()
    {
        return PedidosCancelados.Sum(pedido => pedido.Total) ?? 0;
    }
    private decimal SomaValorTotalPedidosPendentes()
    {
        return PedidosPendentes.Sum(pedido => pedido.Total) ?? 0;
    }
    #endregion
    #region Contadores Pedidos
    private int SomaQtdTotalPedidosValidos()
    {
        return PedidosValidos.Count();
    }
    private int SomaQtdTotalPedidosCancelados()
    {
        return PedidosCancelados.Count();
    }
    private int SomaQtdTotalPedidosPendentes()
    {
        return PedidosPendentes.Count();
    }
    private int SomaQtdTotalPedidos()
    {
        return PedidosValidos.Count() + PedidosCancelados.Count() + PedidosPendentes.Count();
    }
    #endregion
    public List<PedidoDto> PedidosValidos { get; set; } = new List<PedidoDto>();
    public List<PedidoDto> PedidosCancelados { get; set; } = new List<PedidoDto>();
    public List<PedidoDto> PedidosPendentes { get; set; } = new List<PedidoDto>();
    public PedidoDtoResumoSimples(Guid pdvId, List<PedidoDto> pedidosValidos, List<PedidoDto> pedidosCancelados, List<PedidoDto> pedidosPendentes)
    {
        PdvId = pdvId;
        PedidosValidos = pedidosValidos;
        PedidosCancelados = pedidosCancelados;
        PedidosPendentes = pedidosPendentes;
    }
}
