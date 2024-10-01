
using Easy.Domain.Entities.PDV.ItensPedido;

namespace Easy.Services.DTOs.ItemPedido;

public class ItemPedidoDtoResumoSimples
{
    public Guid ProdutoId { get; internal set; }
    public string NomeProduto { get; internal set; }
    public decimal QuantidadeTotal { get; internal set; }    
}
