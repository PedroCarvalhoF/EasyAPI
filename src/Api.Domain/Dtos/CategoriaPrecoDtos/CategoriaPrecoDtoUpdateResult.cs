namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDtoUpdateResult /*: BaseDto*/
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? DescricaoCategoria { get; set; }
        public bool Habilitado { get; set; }

    }
}