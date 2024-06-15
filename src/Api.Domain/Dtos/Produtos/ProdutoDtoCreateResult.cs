namespace Domain.Dtos.Produtos
{
    public class ProdutoDtoCreateResult
    {
        public Guid? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoBarrasPersonalizado { get; set; }
    }
}
