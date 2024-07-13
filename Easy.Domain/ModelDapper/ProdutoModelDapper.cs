namespace Easy.Domain.ModelDapper
{
    public class ProdutoModelDapper
    {
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }        
        public Guid CategoriaProdutoEntityId { get; set; }
        public string? DescricaoCategoria { get; set; }
    }
}
