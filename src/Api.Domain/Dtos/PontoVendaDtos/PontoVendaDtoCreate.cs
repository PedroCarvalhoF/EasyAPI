using Api.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDtoCreate
    {
        [Required]
        public Guid UserIdCreatePdv { get; set; }

        [Required]
        public Guid UserIdResponsavel { get; set; }
        /// <summary>
        ///  1 - almoço
        ///  2 - janta
        ///  3 - dia 
        /// </summary>
        [Required]
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }

    }
}
