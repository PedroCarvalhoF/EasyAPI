using Api.Data.Context;
using Api.Data.Repository;
using Data.Query;
using Domain.Entities.Produto;
using Domain.Interfaces.Repository.Produto;
using Domain.UserIdentity.Masters;
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

        public async Task<IEnumerable<ProdutoEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                IQueryable<ProdutoEntity> query = _dataset.AsNoTracking();

                query = QueryIncludes(query).OrderBy(p => p.NomeProduto);

                query = query.FiltroUserMasterCliente(users);

                var entites = await query.ToArrayAsync();

                return entites;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoEntity> GetByIdProduto(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dataset.AsNoTracking();

                query = query.Where(p => p.Id.Equals(id)).OrderBy(p => p.NomeProduto);

                query = QueryIncludes(query);
                query = query.FiltroUserMasterCliente(users);

                var entity = await query.SingleOrDefaultAsync();

                return entity;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CodigoExists(string? codigoBarrasPersonalizado, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dataset.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).Where(p => p.CodigoBarrasPersonalizado == codigoBarrasPersonalizado);

                var entites = await query.AnyAsync();

                return entites;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> NomeProdutoExists(string? nomeProduto, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dataset.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).Where(p => p.NomeProduto == nomeProduto);

                var entites = await query.AnyAsync();

                return entites;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}