using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDtoCreate
    {
        //[Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Abertura")]
        public Guid UserPdvCreateId { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Utilizar o PDV")]
        public Guid UserPdvUsingId { get; set; }
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid PeriodoPontoVendaEntityId { get; set; }

    }
}
