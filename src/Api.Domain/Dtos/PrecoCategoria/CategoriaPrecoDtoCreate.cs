using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDtoCreate
    {


        [Required]
        [MaxLength(100)]
        public string? DescricaoCategoria { get; set; }

    }
}