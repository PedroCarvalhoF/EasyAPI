using Api.Domain.Entities;
using Api.Domain.Entities.PontoVenda;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PontoVendaPeriodoVenda
{
    public class PeriodoPontoVendaEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Periodo de Venda")]
        [MaxLength(100, ErrorMessage = "{0} -Número máximo de caracteres")]
        public string? DescricaoPeriodo { get; set; }

        IEnumerable<PontoVendaEntity>? PontoVendaEntities { get; set; }

    }
}
