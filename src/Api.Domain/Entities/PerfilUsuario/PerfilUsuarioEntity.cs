using Api.Domain.Entities;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.UsuarioSistema
{
    public class PerfilUsuarioEntity : BaseEntity
    {
        [Key]
        [Required(ErrorMessage = "Informe o nome")]

        [DisplayName("Id Usuário Identity")]
        public Guid IdentityId { get; set; }


        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres: {0}")]
        [DisplayName("Nome do Usuário")]
        public string? Nome { get; set; }

        //PONTO DE VENDA
        public IEnumerable<PontoVendaEntity>? PontoVendaEntitiesAbriu { get; set; }
        public IEnumerable<PontoVendaEntity>? PontoVendaEntitiesUtilizar { get; set; }
        public IEnumerable<ItemPedidoEntity>? ItensPedidoEntities { get; set; }

    }
}
