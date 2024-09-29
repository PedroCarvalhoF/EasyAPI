namespace Easy.Services.DTOs.Pedido.Request;

public class RequestPedidoResumoSimples
{
    public Guid PdvId { get; private set; }

    public RequestPedidoResumoSimples(Guid pdvId)
    {
        PdvId = pdvId;
    }
}
