using Api.Domain.Entities.Pedido;
using Api.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.PontoVenda
{
    public class PontoVendaEntity : BaseEntity
    {
        [Required]
        public Guid UserIdCreatePdv { get; set; }

        [Required]
        public Guid UserIdResponsavel { get; set; }
        [Required]
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }

        [Required]
        public bool AbertoFechado { get; set; }
        public IEnumerable<PedidoEntity>? PedidoEntities { get; set; }
        public DateTime? DataAlteracaoEncerrado { get; set; }

    }
}
