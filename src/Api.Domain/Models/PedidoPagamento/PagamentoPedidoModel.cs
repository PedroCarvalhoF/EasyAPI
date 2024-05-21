using Api.Domain.Models;

namespace Domain.Models.PagamentoPedidoModels
{
    public class PagamentoPedidoModel : BaseModel
    {
        public PagamentoPedidoModel(Guid? id, Guid pedidoEntityId, Guid formaPagamentoEntityId, decimal valorPago)
        {
            PedidoEntityId = pedidoEntityId;
            FormaPagamentoEntityId = formaPagamentoEntityId;
            ValorPago = valorPago;
            if (ValorPago <= 0)
                throw new Exception("O valor informado não pode ser menor ou igual a zero.");
        }

        public Guid PedidoEntityId { get; private set; }
        public Guid FormaPagamentoEntityId { get; private set; }
        public decimal? ValorPago { get; private set; }

        public void AjustarValorTroco(decimal? troco)
        {
            ValorPago += troco;
        }
    }
}
