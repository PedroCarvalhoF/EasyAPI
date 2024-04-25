namespace Api.Domain.Models.PrecoProdutoModels
{
    public class PrecoProdutoModels 
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public Guid ProdutoEntityId { get; set; }
        public Guid CategoriaPrecoEntityId { get; set; }
        public decimal PrecoProduto { get; set; }
       
    }
}