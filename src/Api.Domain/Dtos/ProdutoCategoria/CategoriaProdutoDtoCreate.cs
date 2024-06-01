using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.CategoriaProdutoDtos
{
    public class CategoriaProdutoDtoCreate
    {

        public Guid Id { get; set; }
        [StringLength(30, ErrorMessage = "Categoria deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe Descricao da Categoria")]
        public string? DescricaoCategoria { get; set; }

    }
}
