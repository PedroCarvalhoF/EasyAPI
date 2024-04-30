namespace Domain.Models.ProdutoTipo
{
    public class ProdutoTipoModel
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoTipoProduto { get; set; }
    }
}
