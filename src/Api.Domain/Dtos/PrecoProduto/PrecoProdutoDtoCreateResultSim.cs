namespace Domain.Dtos.PrecoProdutoDtos
{
    public class PrecoProdutoDtoCreateResultSim
    {
        //SIMPLIFICADO TESTE
        public Guid Id { get; set; }

        public Guid ProdutoEntityId { get; set; }
        public String? NomeProduto { get; set; }

        public Guid CategoriaPrecoEntityId { get; set; }
        public String? DescricaoCategoria { get; set; }
        public bool Habilitado { get; set; }
    }
}
