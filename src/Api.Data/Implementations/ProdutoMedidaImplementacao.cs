using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.ProdutoMedida;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Data.Implementations
{
    public class ProdutoMedidaImplementacao : BaseRepository<ProdutoMedidaEntity>, IProdutoMedidaRepository
    {
        private readonly DbSet<ProdutoMedidaEntity> _dbSet;
        public ProdutoMedidaImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<ProdutoMedidaEntity>();
        }

        public async Task<IEnumerable<ProdutoMedidaEntity>> Get(string descricao)
        {
            return await _dbSet
                    .AsNoTracking()
                    .Where(md => md.Descricao.ToLower().Contains(descricao.ToLower()))
                    .ToArrayAsync();
        }
    }
}
