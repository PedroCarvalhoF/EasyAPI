namespace Easy.Services.DTOs.Pedido;

public class PedidoDtoCancelamentoPedidoRequest
{
    public Guid IdPedido { get; set; }
    public required string DescricaoMotivoCancelamento { get; set; }
}
