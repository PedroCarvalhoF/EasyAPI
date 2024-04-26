using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.CategoriaProdutoDtos
{
    public class CategoriaProdutoDtoUpdate
    {
        [Required(ErrorMessage = "Informe Id para realizar alteração")]
        public Guid Id { get; set; }

        [StringLength(100, ErrorMessage = "Categoria deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe Descricao da Categoria")]
        public string? DescricaoCategoria { get; set; }

        [Required]
        public bool StatusCategoria { get; set; }


    }
}
