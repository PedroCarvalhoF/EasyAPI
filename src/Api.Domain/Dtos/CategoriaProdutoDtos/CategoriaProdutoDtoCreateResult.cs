namespace Domain.Dtos.CategoriaProdutoDtos
{
    public class CategoriaProdutoDtoCreateResult
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? DescricaoCategoria { get; set; }
        public bool StatusCategoria { get; set; }
    }
}
