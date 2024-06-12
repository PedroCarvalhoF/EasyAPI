namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid? FiltroId { get; set; }
        public bool Habilitado { get; set; }
    }
}
