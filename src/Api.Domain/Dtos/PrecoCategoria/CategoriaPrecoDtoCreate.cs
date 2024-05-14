using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDtoCreate
    {
        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Categoria de Preço")]
        [MaxLength(80, ErrorMessage = "Quantidade de caracteres deve ser menor ou igual 80")]
        public string? DescricaoCategoria { get; set; }
    }
}