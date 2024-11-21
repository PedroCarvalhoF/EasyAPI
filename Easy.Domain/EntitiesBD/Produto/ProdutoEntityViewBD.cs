namespace Easy.Domain.EntitiesBD.Produto
{
    public class ProdutoEntityViewBD
    {        
        public Guid ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public string Codigo { get; private set; }
        public string ImagemUrl { get; private set; }
        public int MedidaProdutoEnum { get; private set; }
        public int TipoProdutoEnum { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string DescricaoCategoria { get; private set; }
        public Guid UserMasterClienteIdentityId { get; private set; }
        public Guid UserId { get; private set; }
        public ProdutoEntityViewBD(Guid produtoId, string nomeProduto, string codigo, string imagemUrl, int medidaProdutoEnum, int tipoProdutoEnum, Guid categoriaId, string descricaoCategoria, Guid userMasterClienteIdentityId, Guid userId)
        {
            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            Codigo = codigo;
            ImagemUrl = imagemUrl;
            MedidaProdutoEnum = medidaProdutoEnum;
            TipoProdutoEnum = tipoProdutoEnum;
            CategoriaId = categoriaId;
            DescricaoCategoria = descricaoCategoria;
            UserMasterClienteIdentityId = userMasterClienteIdentityId;
            UserId = userId;
        }
    }

    
}
