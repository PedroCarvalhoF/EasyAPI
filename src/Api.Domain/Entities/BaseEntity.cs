namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public DateTime? UpdateAt { get; protected set; }
        public bool Habilitado { get; protected set; }
        public Guid? UserMasterClienteId { get; protected set; }
        public Guid? UserMasterUserId { get; protected set; }

    }
}