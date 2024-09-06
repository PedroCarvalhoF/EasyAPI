namespace Easy.Services.DTOs.Produto
{
    public class ProdutoDtoImageResult
    {
        public Guid IdProduto { get; set; }
        public string Mensagem { get; set; }
        public bool Status { get; set; }
        ProdutoDtoImageResult(Guid idProduto, string mensagem, bool status)
        {
            IdProduto = idProduto;
            Mensagem = mensagem;
            Status = status;
        }

        public static ProdutoDtoImageResult BadRequest()
            => new ProdutoDtoImageResult(Guid.Empty, "Não foi possível alterar imagem", false);
        public static ProdutoDtoImageResult ImagemAlteradaComSucesso(Guid idProduto)
           => new ProdutoDtoImageResult(idProduto, "Não foi possível alterar imagem", true);

    }
}
