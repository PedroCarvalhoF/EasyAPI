using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.FormaPagamentoDtos
{
    public class FormaPagamentoDtoCreate
    {
        [Required]
        [MaxLength(100)]
        public string? DescricaoFormaPg { get; set; }

    }
}
