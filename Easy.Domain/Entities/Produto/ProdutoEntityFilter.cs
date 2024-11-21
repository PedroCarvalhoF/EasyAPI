
namespace Easy.Domain.Entities.Produto
{
    public class ProdutoEntityFilter
    {
    }

    public class ProdutoEntityFilterDapper : IEntityFilter
    {
        //propriedadas/queries
        public Guid? Id { get; set; } = null; //ok
        public bool? GetAll { get; set; } = null; //ok
        public bool? Habilitado { get; set; } = null; //ok
        public string? NomeDescricaoEquals { get; set; } = null; //ok
        public string? NomeDescricaoContains { get; set; } = null; //ok
        public Guid? IdCategoria { get; set; } = null; // ok
        public string? Codigo { get; set; } = null; // ok

    }
}
