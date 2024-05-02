using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PontoVendaPeriodoVendaDtos
{
    public class PeriodoPontoVendaDtoCreate
    {

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Periodo de Venda")]
        public string? DescricaoPeriodo { get; set; }
    }
}
