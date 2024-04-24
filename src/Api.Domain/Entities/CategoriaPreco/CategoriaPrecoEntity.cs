using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PrecoProduto;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.CategoriaPreco
{
    public class CategoriaPrecoEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string? DescricaoCategoria { get; set; }

        public IEnumerable<PrecoProdutoEntity>? PrecoProdutoEntities { get; set; }
        public IEnumerable<PedidoEntity>? PedidoEntities { get; set; }
    }
}
