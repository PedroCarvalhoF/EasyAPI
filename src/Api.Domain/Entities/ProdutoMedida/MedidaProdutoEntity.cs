using Domain.Entities.Produto;

namespace Api.Domain.Entities.ProdutoMedida
{
    public class ProdutoMedidaEntity : BaseEntity
    {
        public string? Descricao { get; set; }
        public IEnumerable<ProdutoEntity>? ProdutoEntities { get; set; }
    }
}