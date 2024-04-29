using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDtoCreate
    {
        [Required]
        public Guid IdPerfilAbriuPDV { get; set; }

        [Required]
        public Guid IdPerfilUtilizarPDV { get; set; }
        [Required]
        public Guid PeriodoPontoVendaEntityId { get; set; }

    }
}
