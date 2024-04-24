using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models.CategoriaPreco
{
    public class CategoriaPrecoModels : BaseModel
    {
        [MaxLength(100)]
        public string? DescricaoCategoria { get; set; }
    }
}