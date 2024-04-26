namespace Domain.Dtos.CategoriaProdutoDtos
{
    public class CategoriaProdutoDtoUpdateResult
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? DescricaoCategoria { get; set; }
        public bool StatusCategoria { get; set; }
    }
}
