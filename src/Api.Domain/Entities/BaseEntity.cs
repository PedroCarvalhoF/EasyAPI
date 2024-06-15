using Domain.UserIdentity.Masters;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public DateTime? UpdateAt { get; protected set; }
        public bool Habilitado { get; protected set; }
        public Guid? UserMasterClienteIdentityId { get; protected set; }
        public Guid? UserId { get; protected set; }
        public bool isBaseValida => ValidarBase();

        private bool ValidarBase()
        {
            if (Id == Guid.Empty)
                return false;
            if (UserId == null || UserId == Guid.Empty)
                return false;
            if (UserMasterClienteIdentityId == null || UserMasterClienteIdentityId == Guid.Empty)
                return false;
            if (CreateAt == default(DateTime))
                return false;

            if (!ValidarBase())
                return false;

            return true;
        }

        protected BaseEntity() { }

        //create
        protected BaseEntity(UserMasterUserDtoCreate users)
        {
            if (users.UserMasterClienteIdentityId == Guid.Empty || users.UserId == Guid.Empty)
                throw new ArgumentException("Informe user master");

            Id = Guid.NewGuid();
            CreateAt = DateTime.UtcNow;
            UpdateAt = null;
            Habilitado = true;
            UserMasterClienteIdentityId = users.UserMasterClienteIdentityId;
            UserId = users.UserId;

        }

        //update
        protected BaseEntity(Guid idBase, bool habilitado, UserMasterUserDtoCreate users)
        {
            if (users.UserMasterClienteIdentityId == Guid.Empty || users.UserId == Guid.Empty)
                throw new ArgumentException("Informe user master");

            Id = idBase;
            UpdateAt = DateTime.Now;
            Habilitado = habilitado;
            UserMasterClienteIdentityId = users.UserMasterClienteIdentityId;
            UserId = users.UserId;
        }

        public void AtulizarData(DateTime dataParaAtualizar)
        {
            CreateAt = dataParaAtualizar;
        }
    }
}