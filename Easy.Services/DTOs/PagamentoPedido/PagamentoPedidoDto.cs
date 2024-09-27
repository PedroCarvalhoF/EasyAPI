namespace Easy.Services.DTOs.PagamentoPedido;
public class PagamentoPedidoDto
{
    public Guid FormaPagamentoId { get; private set; }
    public string? FormaPagamento { get; private set; }
    public Guid PedidoId { get; private set; }
    public decimal ValorPago { get; private set; }
    public PagamentoPedidoDto(Guid formaPagamentoId, string? formaPagamento, Guid pedidoId, decimal valorPago)
    {
        FormaPagamentoId = formaPagamentoId;
        FormaPagamento = formaPagamento;
        PedidoId = pedidoId;
        ValorPago = valorPago;
    }
}
