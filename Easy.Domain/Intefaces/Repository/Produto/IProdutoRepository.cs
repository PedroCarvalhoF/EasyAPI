using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface IProdutoRepository<T, F> where T : ProdutoEntity where F : FiltroBase
    {       
    }
}
