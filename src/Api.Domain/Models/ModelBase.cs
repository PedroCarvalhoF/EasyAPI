namespace Api.Domain.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
    }
}
