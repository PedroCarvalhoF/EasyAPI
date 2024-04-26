using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Produto;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ProdutoImplementation : BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private readonly DbSet<ProdutoEntity> _dataset;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProdutoEntity>();
            _dataset.AsNoTracking();
        }


        public async Task<IEnumerable<ProdutoEntity>> Get()
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset;


                query = QueryIncludes(query);

                var entites = await query.ToArrayAsync();

                return entites;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ProdutoEntity> Get(Guid id)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset;

                query = query.Where(p => p.Id.Equals(id));

                query = QueryIncludes(query);

                var entity = await query.FirstOrDefaultAsync();

                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> Get(string nomeProduto)
        {
            IQueryable<ProdutoEntity> query = _dataset;

            query = query.Where(p => p.NomeProduto.ToLower().Contains(nomeProduto.ToLower()));

            query = QueryIncludes(query);

            var entity = await query.ToArrayAsync();

            return entity;
        }



        public async Task<IEnumerable<ProdutoEntity>> GetCategoria(Guid categoriaId)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset;
                query = query.Where(p => p.CategoriaProdutoEntityId.Equals(categoriaId));

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();
                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProdutoEntity> GetCodigo(string codigoPersonalizado)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset;
                query = query.Where(p => p.CodigoBarrasPersonalizado.Equals(codigoPersonalizado));

                query = QueryIncludes(query);

                var entity = await query.SingleOrDefaultAsync();
                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            IQueryable<ProdutoEntity> query = _dataset;
            query = query.Where(p => p.Habilitado.Equals(habilitado));

            query = QueryIncludes(query);

            var entities = await query.ToArrayAsync();
            return entities;
        }

        public async Task<IEnumerable<ProdutoEntity>> GetMedida(Guid id)
        {
            IQueryable<ProdutoEntity> query = _dataset;
            query = query.Where(p => p.ProdutoMedidaEntityId.Equals(id));

            query = QueryIncludes(query);

            var entities = await query.ToArrayAsync();
            return entities;
        }

        public async Task<IEnumerable<ProdutoEntity>> GetProdutoTipo(Guid id)
        {
            IQueryable<ProdutoEntity> query = _dataset;
            query = query.Where(p => p.ProdutoTipoEntityId.Equals(id));

            query = QueryIncludes(query);

            var entities = await query.ToArrayAsync();
            return entities;
        }


        private IQueryable<ProdutoEntity> QueryIncludes(IQueryable<ProdutoEntity> query)
        {
            query = query
                .Include(cat => cat.CategoriaProdutoEntity)
                .Include(tipo => tipo.ProdutoTipoEntity)
                .Include(medida => medida.ProdutoMedidaEntity);

            return query;

        }
    }
}