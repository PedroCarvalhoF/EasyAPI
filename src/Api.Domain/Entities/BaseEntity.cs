namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime? CreateAt { get; protected set; }
        public DateTime? UpdateAt { get; protected set; }
        public bool Habilitado { get; protected set; }
        public Guid? UserMasterClienteIdentityId { get; protected set; }
        public Guid? UserId { get; protected set; }

        protected BaseEntity() { }

        protected BaseEntity(Guid? userMasterClienteIdentityId, Guid? userId)
        {
            if (!userMasterClienteIdentityId.HasValue)
                throw new ArgumentException("UserMasterClienteIdentityId não pode ser nulo.");
            if (!userId.HasValue)
                throw new ArgumentException("UserId não pode ser nulo.");

            Id = Guid.NewGuid();
            CreateAt = DateTime.UtcNow;
            Habilitado = true;
            UserMasterClienteIdentityId = userMasterClienteIdentityId;
            UserId = userId;
        }

        public void SetUserDetails(Guid? userMasterClienteIdentityId, Guid? userId)
        {
            if (!userMasterClienteIdentityId.HasValue)
                throw new ArgumentException("UserMasterClienteIdentityId não pode ser nulo.");
            if (!userId.HasValue)
                throw new ArgumentException("UserId não pode ser nulo.");

            UserMasterClienteIdentityId = userMasterClienteIdentityId;
            UserId = userId;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        protected void UpdateTimestamp()
        {
            UpdateAt = DateTime.UtcNow;
        }

        public void Habilitar()
        {
            Habilitado = true;
            UpdateTimestamp();
        }

        public void Desabilitar()
        {
            Habilitado = false;
            UpdateTimestamp();
        }

        public void ChangeUser(Guid? userMasterClienteIdentityId, Guid? userId)
        {
            if (!userMasterClienteIdentityId.HasValue)
                throw new ArgumentException("UserMasterClienteIdentityId não pode ser nulo.");
            if (!userId.HasValue)
                throw new ArgumentException("UserId não pode ser nulo.");

            UserMasterClienteIdentityId = userMasterClienteIdentityId;
            UserId = userId;
            UpdateTimestamp();
        }
    }
}