using Easy.Domain.Entities.Produto;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Tools.Produto
{
    public static class ProdutoEntityExtensionsInclude
    {
        public static IQueryable<ProdutoEntity> IncludeProdutos(this IQueryable<ProdutoEntity> query)
        {
            return query.Include(p => p.CategoriaProdutoEntity);
        }
    }
}