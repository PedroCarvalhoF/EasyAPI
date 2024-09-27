namespace Easy.Services.DTOs.PagamentoPedido
{
    public class PagamentoPedidoDtoInserir
    {
        public Guid FormaPagamentoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public decimal ValorPago { get; private set; }
        public PagamentoPedidoDtoInserir(Guid formaPagamentoId, Guid pedidoId, decimal valorPago)
        {
            FormaPagamentoId = formaPagamentoId;
            PedidoId = pedidoId;
            ValorPago = valorPago;
        }
    }
}
