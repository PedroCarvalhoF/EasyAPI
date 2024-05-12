using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Microsoft.AspNetCore.Identity;


namespace Domain.Identity.UserIdentity
{
    public class User : IdentityUser<Guid>
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? ImagemURL { get; set; }
        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntitiesCreate { get; set; }

        public IEnumerable<PontoVendaEntity>? UserPontoVendaCreate { get; set; }
        public IEnumerable<PontoVendaEntity>? UserPontoVendaUsing { get; set; }
    }
}