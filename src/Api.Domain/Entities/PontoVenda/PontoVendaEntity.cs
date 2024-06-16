using Api.Domain.Entities.Pedido;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Entities.PontoVenda
{
    public class PontoVendaEntity : BaseEntity
    {
        public Guid UserPdvCreateId { get; private set; }
        public UsuarioPontoVendaEntity? UserPdvCreate { get; private set; }
        public Guid UserPdvUsingId { get; private set; }
        public UsuarioPontoVendaEntity? UserPdvUsing { get; private set; }
        public Guid PeriodoPontoVendaEntityId { get; private set; }
        public PeriodoPontoVendaEntity? PeriodoPontoVendaEntity { get; private set; }
        public bool AbertoFechado { get; private set; }
        public IEnumerable<PedidoEntity>? PedidoEntities { get; private set; }
        public bool Validada => Validar();

        private bool Validar()
        {
            if (UserPdvCreateId == Guid.Empty)
                return false;
            if (UserPdvUsingId == Guid.Empty)
                return false;
            if (PeriodoPontoVendaEntityId == Guid.Empty)
                return false;

            return true;
        }

        public PontoVendaEntity() { }
        public PontoVendaEntity(Guid userPdvCreateId, Guid userPdvUsingId, Guid periodoPontoVendaEntityId, UserMasterUserDtoCreate users) : base(users)
        {
            if (userPdvCreateId == Guid.Empty)
                throw new ArgumentException("Informe o id reponsável pelo abertura.");
            if (userPdvUsingId == Guid.Empty)
                throw new ArgumentException("Informe o id reponsável por utilizar o pdv.");
            if (periodoPontoVendaEntityId == Guid.Empty)
                throw new ArgumentException("Informe o id periodo do pdv.");

            UserPdvCreateId = userPdvCreateId;
            UserPdvUsingId = userPdvUsingId;
            PeriodoPontoVendaEntityId = periodoPontoVendaEntityId;
            AbertoFechado = true;
        }

        public PontoVendaEntity(Guid id, Guid userPdvCreateId, Guid userPdvUsingId, Guid periodoPontoVendaEntityId, bool abertoFechado, UserMasterUserDtoCreate users) : base(id, true, users)
        {
            if (userPdvCreateId == Guid.Empty)
                throw new ArgumentException("Informe o id reponsável pelo abertura.");
            if (userPdvUsingId == Guid.Empty)
                throw new ArgumentException("Informe o id reponsável por utilizar o pdv.");
            if (periodoPontoVendaEntityId == Guid.Empty)
                throw new ArgumentException("Informe o id periodo do pdv.");

            UserPdvCreateId = userPdvCreateId;
            UserPdvUsingId = userPdvUsingId;
            PeriodoPontoVendaEntityId = periodoPontoVendaEntityId;
            AbertoFechado = abertoFechado;
        }
        public void EncerrarPontoVendaEntity()
        {
            this.AbertoFechado = false;
            UpdateAt = DateTime.Now;
        }

    }
}
