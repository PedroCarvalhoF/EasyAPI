using Api.Domain.Entities;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Identity.UserIdentity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PontoVendaUser
{
    public class UsuarioPontoVendaEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id usuário")]
        public Guid UserId { get; set; }
        public User? User { get; set; }


        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntities { get; set; }
        public IEnumerable<PontoVendaEntity>? UserPontoVendaCreate { get; set; }
        public IEnumerable<PontoVendaEntity>? UserPontoVendaUsing { get; set; }
    }
}
