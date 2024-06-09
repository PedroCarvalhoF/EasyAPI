using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Produto;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Produto
{
    public class ProdutoImplementation : BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private readonly DbSet<ProdutoEntity> _dataset;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProdutoEntity>();
            _dataset.AsNoTracking();
        }
        private IQueryable<ProdutoEntity> QueryIncludes(IQueryable<ProdutoEntity> query)
        {
            query = query
                         .Include(cat => cat.CategoriaProdutoEntity)
                         .Include(tipo => tipo.ProdutoTipoEntity)
                         .Include(medida => medida.ProdutoMedidaEntity);

            return query;

        }

        public async Task<IEnumerable<ProdutoEntity>> Get()
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = QueryIncludes(query).OrderBy(p => p.NomeProduto);

                var entites = await query.ToArrayAsync();

                return entites;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoEntity> Get(Guid id)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(p => p.Id.Equals(id)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entity = await query.FirstOrDefaultAsync();

                return entity;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntity>> Get(string nomeProduto)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(p => p.NomeProduto.ToLower().Contains(nomeProduto.ToLower())).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entity = await query.ToArrayAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntity>> GetCategoria(Guid categoriaId)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(p => p.CategoriaProdutoEntityId.Equals(categoriaId)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoEntity> GetCodigo(string codigoPersonalizado)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(p => p.CodigoBarrasPersonalizado.Equals(codigoPersonalizado)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entity = await query.SingleOrDefaultAsync();
                return entity;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntity>> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();
                query = query.Where(p => p.Habilitado.Equals(habilitado)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();
                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntity>> GetMedida(Guid id)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();
                query = query.Where(p => p.ProdutoMedidaEntityId.Equals(id)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();
                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ProdutoEntity>> GetProdutoTipo(Guid id)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();
                query = query.Where(p => p.ProdutoTipoEntityId.Equals(id)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> GetProdutosByPdvAsync(Guid idPdv)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = query.Where(p => p.ItensPedidoEntities.Any(p => p.PedidoEntity.PontoVendaEntityId == idPdv)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);

                var entities = await query.ToArrayAsync();
                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}