namespace Easy.Domain.Entities.Produto
{
    internal class ProdutoEntityFilter
    {
    }

    public class ProdutoEntityFilterDapper : IEntityFilter
    {
        public bool? GetAll { get; set; } = null;
        public bool? Habilitado { get; set; } = null;
    }
}
