
namespace Easy.Domain.Entities.PDV.PrecoProduto
{
    public class PrecoProdutoEntityFilter
    {
    }
    public class PrecoProdutoEntityFilterDapper : IEntityFilter
    {
        public Guid? Id { get; set; } = null;
        public bool? GetAll { get; set; } = null;
        public string? NomeDescricaoEquals { get; set; } = null;
        public string? NomeDescricaoContains { get; set; } = null;
        public bool? Habilitado { get; set; } = null;
    }
}
