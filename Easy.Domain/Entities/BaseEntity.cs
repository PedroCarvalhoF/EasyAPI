using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; protected set; }
        public bool Habilitado { get; protected set; }
        public Guid UserMasterClienteIdentityId { get; protected set; }
        public Guid UserId { get; protected set; }
        public bool isBaseValida => ValidarBase();

        private bool ValidarBase()
        {
            if (Id == Guid.Empty)
                return false;
            if (UserId == null || UserId == Guid.Empty)
                return false;
            if (UserMasterClienteIdentityId == null || UserMasterClienteIdentityId == Guid.Empty)
                return false;

            return true;
        }

        protected BaseEntity() { }

        //create
        protected BaseEntity(FiltroBase users)
        {
            DomainValidation.When(users.clienteId == Guid.Empty,
                                 "Informe o id do Cliente Master");
            DomainValidation.When(users.userId == Guid.Empty,
                                 "Informe o id do Usuário Master");

            Id = Guid.NewGuid();
            CreateAt = DateTime.UtcNow;
            UpdateAt = null;
            Habilitado = true;
            UserMasterClienteIdentityId = users.clienteId;
            UserId = users.userId;

        }

        //update
        protected BaseEntity(Guid idBase, bool habilitado, FiltroBase users)
        {
            DomainValidation.When(users.clienteId == Guid.Empty,
                                "Informe o id do Cliente Master");
            DomainValidation.When(users.userId == Guid.Empty,
                                 "Informe o id do Usuário Master");
            DomainValidation.When(idBase == Guid.Empty,
                                  "Informe o id para realizar alteração");

            Id = idBase;
            UpdateAt = DateTime.Now;
            Habilitado = habilitado;
            UserMasterClienteIdentityId = users.clienteId;
            UserId = users.userId;
        }
        public void DataCriacao(DateTime dataParaAtualizar)
        {
            CreateAt = dataParaAtualizar;
        }

        public void Atualizacao()
        {
            UpdateAt = DateTime.Now;
        }

    }
}