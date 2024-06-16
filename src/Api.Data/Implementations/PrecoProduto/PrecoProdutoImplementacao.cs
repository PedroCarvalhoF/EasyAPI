using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Data.Query;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PrecoProduto
{
    public class PrecoProdutoImplementacao : BaseRepository<PrecoProdutoEntity>, IPrecoProdutoRepository
    {
        private readonly DbSet<PrecoProdutoEntity> _dtSet;
        public PrecoProdutoImplementacao(MyContext context) : base(context)
        {
            _dtSet = context.Set<PrecoProdutoEntity>();
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

        public async Task<IEnumerable<PrecoProdutoEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dtSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                query = Includes(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PrecoProdutoEntity> PrecoProdutoExists(PrecoProdutoDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dtSet.AsNoTracking();

                //ATENÇÃO PRECISA SER CRIADO UM METODO - TEMPORARIO
                query = Includes(query);

                query = query.FiltroUserMasterCliente(users)
                    .Where(p => p.CategoriaPrecoEntityId == create.CategoriaPrecoEntityId
                    && p.ProdutoEntityId == create.ProdutoEntityId);

                var entity = await query.SingleOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}