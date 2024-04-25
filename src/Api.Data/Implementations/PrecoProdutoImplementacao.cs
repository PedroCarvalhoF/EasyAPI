using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.PrecoProduto;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Implementations
{
    public class PrecoProdutoImplementacao : BaseRepository<PrecoProdutoEntity>, IPrecoProdutoRepository
    {
        private readonly DbSet<PrecoProdutoEntity> _dataset;
        public PrecoProdutoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PrecoProdutoEntity>();

        }

        public async Task<PrecoProdutoEntity> ConsultarPrecoByID(Guid id)
        {
            return null;

            //IQueryable<PrecoProdutoEntity>? query = _context.PrecosProdutos;
            //query = query?.Include(prod => prod.ProdutoEntity).
            //    ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);
            //query = query?.Include(cat => cat.CategoriaPrecoEntity);

            //query = query?.Where(pr => pr.Id.Equals(id));

            //PrecoProdutoEntity? entity = await query?.AsNoTracking().FirstOrDefaultAsync();
            //return entity;
        }

        public async Task<IEnumerable<PrecoProdutoEntity>> Get(Expression<Func<PrecoProdutoEntity, bool>> funcao, bool inlude = true)
        {
            return null;
            //IQueryable<PrecoProdutoEntity>? query = _context.PrecosProdutos;

            //if (inlude)
            //{
            //    query = query?.Include(prod => prod.ProdutoEntity).ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);
            //    query = query?.Include(cat => cat.CategoriaPrecoEntity);
            //}

            //query = query?.Where(funcao);

            //PrecoProdutoEntity[] entities = await query.AsNoTracking().ToArrayAsync();

            //return entities;
        }

        public async Task<PrecoProdutoEntity> GetById(Guid id)
        {
            return await _dataset.AsNoTracking()
                     .Include(produto => produto.ProdutoEntity)
                     .Include(categoria => categoria.CategoriaPrecoEntity)
                     .SingleOrDefaultAsync(pr => pr.Id.Equals(id));
        }

        public async Task<PrecoProdutoEntity> GetExistPrecoProduto(Guid produtoId, Guid categoriaPrecoId)
        {
            try
            {
                PrecoProdutoEntity? precoProdutoEntity = await
                    _dataset.AsNoTracking()
                    .FirstOrDefaultAsync(pr => pr.ProdutoEntityId.Equals(produtoId) && pr.CategoriaPrecoEntityId.Equals(categoriaPrecoId));

                return precoProdutoEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
