using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.PedidoSituacao;
using Domain.Interfaces.Repository.PedidoSituacao;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PedidoSituacao
{
    public class SituacaoPedidoImplementacao : BaseRepository<SituacaoPedidoEntity>, ISituacaoPedidoRepository
    {
        private readonly DbSet<SituacaoPedidoEntity> _dbSet;
        public SituacaoPedidoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<SituacaoPedidoEntity>();
            _dbSet.AsNoTracking();
        }

        public async Task<IEnumerable<SituacaoPedidoEntity>> Get(string descricao)
        {
            try
            {
                IQueryable<SituacaoPedidoEntity> query = _dbSet.AsNoTracking();

                query = query.Where(sit => sit.DescricaoSituacao.ToLower().Contains(descricao.ToLower()));

                SituacaoPedidoEntity[] resultEntities = await query.ToArrayAsync();

                return resultEntities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
