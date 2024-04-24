using Api.Domain.Entities.PrecoProduto;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public interface IPrecoProdutoRepository
    {
        Task<PrecoProdutoEntity> GetById(Guid id);
        Task<PrecoProdutoEntity> GetExistPrecoProduto(Guid produtoId, Guid categoriaPrecoId);
        Task<IEnumerable<PrecoProdutoEntity>> Get(Expression<Func<PrecoProdutoEntity, bool>> funcao, bool inlude = false);
        Task<PrecoProdutoEntity> ConsultarPrecoByID(Guid id);
    }
}
