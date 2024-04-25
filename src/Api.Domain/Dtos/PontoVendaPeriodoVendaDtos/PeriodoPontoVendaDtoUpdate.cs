using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PontoVendaPeriodoVendaDtos
{
    public class PeriodoPontoVendaDtoUpdate
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Periodo de Venda")]
        public string? DescricaoPeriodo { get; set; }
        
        [Required(ErrorMessage = "Informe se esta {0} ou não.")]
        [Display(Name = "Habilitado")]
        public bool Habilitado { get; set; }
    }
}
