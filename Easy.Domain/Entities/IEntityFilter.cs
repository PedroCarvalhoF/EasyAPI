namespace Easy.Domain.Entities
{
    public interface IEntityFilter
    {
        Guid? Id { get; set; }
        bool? GetAll { get; set; }
        bool? Habilitado { get; set; }
        string? NomeDescricaoEquals { get; set; }
        string? NomeDescricaoContains { get; set; }
    }
}
