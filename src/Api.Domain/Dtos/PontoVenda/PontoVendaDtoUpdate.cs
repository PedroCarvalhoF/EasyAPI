using Api.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDtoUpdate
    {

        [Required]
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }
        /// <summary>
        /// ABERTO = TREU
        /// ENCERRADO = FALSE
        /// </summary>
        [Required]
        public bool AbertoFechado { get; set; }
        public DateTime? DataAlteracaoEncerrado { get; set; }
    }
}
