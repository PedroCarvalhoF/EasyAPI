using Easy.Domain.Entities.PDV.PrecoProduto;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Tools.PrecoProduto
{
    public static class PrecoProdutoEntityExtensionsInclude
    {
        public static IQueryable<PrecoProdutoEntity> IncludePrecosProdutos(this IQueryable<PrecoProdutoEntity> query)
        {
            return
                query
                .Include(preco => preco.Produto)
                .ThenInclude(prod => prod.CategoriaProdutoEntity)
                .Include(preco => preco.CategoriaPreco);
        }
    }
}
