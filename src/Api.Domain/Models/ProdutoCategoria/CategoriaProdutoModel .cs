using Domain.Dtos.ProdutoDtos;

namespace Api.Domain.Models.CategoriaProdutoModels
{
    public class CategoriaProdutoModel : ModelBase
    {
        public string? DescricaoCategoria { get; set; }
        public bool StatusCategoria { get; set; }
    }
}
