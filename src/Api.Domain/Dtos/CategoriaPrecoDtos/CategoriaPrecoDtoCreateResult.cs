namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDtoCreateResult : BaseDto
    {
        public string? DescricaoCategoria { get; set; }
        public bool Habilitado { get; set; }
    }
}