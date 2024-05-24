using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.PrecoProduto;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PrecoProdutoImplementacao : BaseRepository<PrecoProdutoEntity>, IPrecoProdutoRepository
    {
        private readonly DbSet<PrecoProdutoEntity> _dtSet;
        public PrecoProdutoImplementacao(MyContext context) : base(context)
        {
            _dtSet = context.Set<PrecoProdutoEntity>();
            _dtSet.AsNoTracking();

        }

        private IQueryable<PrecoProdutoEntity> Includes(IQueryable<PrecoProdutoEntity> query)
        {
            query = query.Include(cat_preco => cat_preco.CategoriaPrecoEntity);

            query = query.Include(prod => prod.ProdutoEntity)
                         .Include(cat => cat.ProdutoEntity.CategoriaProdutoEntity)
                         .Include(pm => pm.ProdutoEntity.ProdutoMedidaEntity)
                         .Include(pt => pt.ProdutoEntity.ProdutoTipoEntity);

            return query;
        }
        public async Task<IEnumerable<PrecoProdutoEntity>> GetAll()
        {
            try
            {
                IQueryable<PrecoProdutoEntity> query = _dtSet.AsNoTracking();

                query = Includes(query);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PrecoProdutoEntity> Get(Guid id)
        {
            try
            {
                IQueryable<PrecoProdutoEntity> query = _dtSet.AsNoTracking();

                query = Includes(query);

                query = query.Where(preco => preco.Id.Equals(id));

                return await query.SingleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PrecoProdutoEntity>> GetProdutoId(Guid id)
        {
            try
            {
                IQueryable<PrecoProdutoEntity> query = _dtSet.AsNoTracking();

                query = query.Where(preco => preco.ProdutoEntity.Id.Equals(id));

                query = Includes(query);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PrecoProdutoEntity>> GetCategoriaPrecoId(Guid id)
        {
            try
            {
                IQueryable<PrecoProdutoEntity> query = _dtSet.AsNoTracking();

                query = query.Where(preco => preco.CategoriaPrecoEntityId.Equals(id));

                query = Includes(query);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PrecoProdutoEntity> PrecoExists(Guid produtoEntityId, Guid categoriaPrecoEntityId)
        {
            try
            {
                IQueryable<PrecoProdutoEntity> query = _dtSet.AsNoTracking();

                query = query.Where(preco => preco.ProdutoEntity.Id.Equals(produtoEntityId) && preco.CategoriaPrecoEntity.Id.Equals(categoriaPrecoEntityId));

                var result = await query.FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
