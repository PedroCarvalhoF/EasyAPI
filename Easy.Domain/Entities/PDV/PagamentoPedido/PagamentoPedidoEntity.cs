using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.PagamentoPedido;

public class PagamentoPedidoEntity : BaseEntity
{
    public Guid FormaPagamentoId { get; private set; }
    public FormaPagamentoEntity? FormaPagamento { get; private set; }
    public Guid PedidoId { get; private set; }
    public PedidoEntity? Pedido { get; private set; }
    public decimal ValorPago { get; private set; }

    public bool Validada => Validar();

    private bool Validar()
    {
        if (FormaPagamentoId == Guid.Empty) return false;
        if (PedidoId == Guid.Empty) return false;
        if (ValorPago <= 0) return false;

        return true;
    }

    public PagamentoPedidoEntity() { }
    PagamentoPedidoEntity(Guid formaPagamentoId, Guid pedidoId, decimal valorPago, FiltroBase user) : base(user)
    {
        DomainValidation.When(formaPagamentoId == Guid.Empty, "Informe o id da forma de pagamento.");
        DomainValidation.When(pedidoId == Guid.Empty, "Informe o id do pedido.");
        DomainValidation.When(valorPago <= 0, "Valor pago não pode ser menor ou igual a zero.");

        FormaPagamentoId = formaPagamentoId;
        PedidoId = pedidoId;
        ValorPago = valorPago;
    }

    public static PagamentoPedidoEntity Inserir(Guid formaPagamentoId, Guid pedidoId, decimal valorPago, FiltroBase user)
        => new PagamentoPedidoEntity(formaPagamentoId, pedidoId, valorPago, user);
}
