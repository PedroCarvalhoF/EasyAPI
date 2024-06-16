namespace Domain.Dtos.PrecoProduto
{
    public class PrecoProdutoView
    {
        public PrecoProdutoView(Guid id, string? nomeProduto, string? categoriaPreco, decimal precoP)
        {
            Id = id;
            NomeProduto = nomeProduto;
            CategoriaPreco = categoriaPreco;
            PrecoProduto = precoP;
        }

        public Guid Id { get; private set; }
        public string? NomeProduto { get; private set; }
        public string? CategoriaPreco { get; private set; }
        public decimal PrecoProduto { get; private set; }
    }
}
