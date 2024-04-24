using Api.Domain.Entities;
using Domain.Entities.Produto;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.ProdutoTipo
{
    public class ProdutoTipoEntity : BaseEntity
    {
        [Display(Name = "Venda/Mat.Prima")]
        public string? DescricaoTipoProduto { get; set; }
        public IEnumerable<ProdutoEntity>? ProdutoEntities { get; set; }

    }
}


//MateriaPrima = 1,
//        Venda = 2,
//        Ambos = 3
