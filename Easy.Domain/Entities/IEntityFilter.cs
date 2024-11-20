namespace Easy.Domain.Entities
{
    public interface IEntityFilter
    {
        bool? GetAll { get; set; }
        bool? Habilitado { get; set; }
    }
}
