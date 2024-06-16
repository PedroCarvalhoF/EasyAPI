namespace Domain.Dtos.Produtos
{
    public class ProdutoView
    {
        public ProdutoView(Guid id, string nomeProduto, string codigoBarrasPersonalizado, string categoriaDescricao, string medidaDescricao, string tipoDescricao, string imgUrl)
        {
            Id = id;
            NomeProduto = nomeProduto;
            CodigoBarrasPersonalizado = codigoBarrasPersonalizado;
            CategoriaDescricao = categoriaDescricao;
            MedidaDescricao = medidaDescricao;
            TipoDescricao = tipoDescricao;
            ImgUrl = imgUrl;
        }

        public Guid Id { get; private set; }
        public string NomeProduto { get; private set; }
        public string CodigoBarrasPersonalizado { get; private set; }
        public string CategoriaDescricao { get; private set; }
        public string MedidaDescricao { get; private set; }
        public string TipoDescricao { get; private set; }
        public string ImgUrl { get; private set; }

    }
}
