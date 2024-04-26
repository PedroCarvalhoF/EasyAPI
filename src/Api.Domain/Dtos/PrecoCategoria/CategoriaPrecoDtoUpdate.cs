using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? DescricaoCategoria { get; set; }
        [Required]
        public bool Habilitado { get; set; }
    }
}