using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.FormaPagamentoDtos
{
    public class FormaPagamentoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? DescricaoFormaPg { get; set; }
        [Required]
        public bool Habilitado { get; set; }
    }
}
