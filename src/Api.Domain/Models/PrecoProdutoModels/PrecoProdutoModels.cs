namespace Api.Domain.Models.PrecoProdutoModels
{
    public class PrecoProdutoModels : BaseModel
    {
        public Guid ProdutoEntityId { get; set; }
        public Guid CategoriaPrecoEntityId { get; set; }
        public Decimal PrecoProduto { get; set; }
        public bool Habilitado { get; set; }
    }
}