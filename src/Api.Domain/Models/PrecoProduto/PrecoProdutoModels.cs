namespace Api.Domain.Models.PrecoProdutoModels
{
    public class PrecoProdutoModels 
    {
        
        public Guid ProdutoEntityId { get; set; }       
        public Guid CategoriaPrecoEntityId { get; set; }     
        public decimal PrecoProduto { get; set; }
    }
}