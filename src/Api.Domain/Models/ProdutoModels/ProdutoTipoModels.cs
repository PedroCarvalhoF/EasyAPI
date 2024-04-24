namespace Domain.Models.ProdutoModels
{
    public class ProdutoTipoModels
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoTipoProduto { get; set; }
    }
}
