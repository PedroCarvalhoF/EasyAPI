using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
    }
}
