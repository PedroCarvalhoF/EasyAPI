using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.PeriodoPdv
{
    public class PeriodoPdvDtoCreate
    {
        [Required]
        public string DescricaoPeriodo { get; private set; }

        public PeriodoPdvDtoCreate(string descricaoPeriodo)
        {
            DescricaoPeriodo = descricaoPeriodo;
        }
    }
}
