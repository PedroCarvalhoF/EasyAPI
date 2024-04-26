namespace Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoClean
    {
        public PrecoProdutoDtoClean(Guid id, DateTime? createAt, Guid idProduto, string? nomeProduto, Guid idCategoriaPreco, string? categoriaPreco, decimal preco, bool habilitado)
        {
            Id = id;
            CreateAt = createAt;
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
            IdCategoriaPreco = idCategoriaPreco;
            CategoriaPreco = categoriaPreco;
            this.Preco = preco;
            Habilitado = habilitado;
        }

        public Guid Id { get; private set; }
        public DateTime? CreateAt { get; private set; }
        public Guid IdProduto { get; private set; }
        public string? NomeProduto { get; private set; }
        public Guid IdCategoriaPreco { get; private set; }
        public string? CategoriaPreco { get; private set; }
        public Decimal? Preco { get; private set; }
        public bool Habilitado { get; private set; }
    }
}
