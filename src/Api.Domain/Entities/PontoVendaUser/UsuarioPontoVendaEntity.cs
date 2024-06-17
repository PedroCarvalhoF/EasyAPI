using Api.Domain.Entities;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Identity.UserIdentity;
using Domain.UserIdentity.Masters;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PontoVendaUser
{
    public class UsuarioPontoVendaEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id usuário")]
        public Guid UserId { get; private set; }
        public virtual User? UserPdv { get; private set; }
        public bool Validada => Validar();

        private bool Validar()
        {
            if (UserId == Guid.Empty)
                return false;

            return true;
        }

        public virtual ICollection<ItemPedidoEntity>? ItemPedidoEntities { get; private set; }
        public virtual ICollection<PontoVendaEntity>? UserPontoVendaCreate { get; private set; }
        public virtual ICollection<PontoVendaEntity>? UserPontoVendaUsing { get; private set; }
        public UsuarioPontoVendaEntity() { }

        private UsuarioPontoVendaEntity(Guid userId, UserMasterUserDtoCreate users) : base(users)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Informe o id do usuário");

            UserId = userId;
        }

        public static UsuarioPontoVendaEntity CreateUsuarioPontoVenda(Guid userId, UserMasterUserDtoCreate users)
            => new UsuarioPontoVendaEntity(userId, users);
    }
}
