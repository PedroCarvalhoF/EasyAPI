namespace Domain.Models.ProdutoModels
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoBarrasPersonalizado { get; set; }
        public string? Descricao { get; set; }
        public string? Observacoes { get; set; }
        public Guid CategoriaProdutoEntityId { get; set; }
        public Guid? ProdutoMedidaEntityId { get; set; }
        public Guid? ProdutoTipoEntityId { get; set; }
        public string? ImgUrl { get; set; }

        public void Desabilitar()
        {
            this.Habilitado = false;
            this.Observacoes = $"Produto desabilitado em: {DateTime.Now}";
        }

        public void Update()
        {
            UpdateAt = DateTime.Now;
            Observacoes = $"Este produto ja foi alterado {UpdateAt}";
        }
    }
}
