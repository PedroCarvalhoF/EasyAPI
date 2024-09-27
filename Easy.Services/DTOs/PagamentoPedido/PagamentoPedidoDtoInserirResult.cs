namespace Easy.Services.DTOs.PagamentoPedido
{
    public class PagamentoPedidoDtoInserirResult
    {
        public Guid PedidoId { get; private set; }
        public bool PedidoFinalizado { get; private set; } = false;
        public decimal TotalPedido { get; private set; } = 0;
        public decimal TotalPago => CalcularTotalPago();
        public decimal FaltaReceber => CalcularFaltaReceber();
        public decimal Troco { get; private set; } = 0;
        public List<PagamentoPedidoDto>? PagamentosPedido { get; private set; } = new List<PagamentoPedidoDto>();      
        private decimal CalcularFaltaReceber()
        {
            if (PagamentosPedido == null || PagamentosPedido.Count == 0)
                return TotalPedido;

            var falta_receber = TotalPedido - TotalPago;
            return falta_receber > 0 ? falta_receber : 0;
        }
        private decimal CalcularTotalPago()
        {
            if (PagamentosPedido!.Count == 0)
                return 0;

            return PagamentosPedido.Sum(p => p.ValorPago);
        }

        public PagamentoPedidoDtoInserirResult(Guid pedidoId, bool pedidoFinalizado, List<PagamentoPedidoDto>? pagamentos, decimal troco, decimal totalPedido)
        {
            PedidoId = pedidoId;
            PedidoFinalizado = pedidoFinalizado;
            PagamentosPedido = pagamentos;
            Troco = troco;
            TotalPedido = totalPedido;
        }
    }
}
