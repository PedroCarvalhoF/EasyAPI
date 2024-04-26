namespace Api.Domain.Models.CategoriaPreco
{
    public class CategoriaPrecoModels 
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoCategoria { get; set; }
    }
}