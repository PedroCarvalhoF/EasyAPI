namespace Api.Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoCreateResult
    {
        public PrecoProdutoDtoCreateResult(Guid id, string nomeProduto, string categoriaPreco, decimal preco)
        {
            Id = id;
            NomeProduto = nomeProduto;
            CategoriaPreco = categoriaPreco;
            this.preco = preco;
        }

        public Guid Id { get; private set; }
        public string NomeProduto { get; private set; }
        public string CategoriaPreco { get; private set; }
        public decimal preco { get; private set; }

    }
}