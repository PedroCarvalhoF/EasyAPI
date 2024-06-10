using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Repository.Pessoa.Funcionario.Funcao;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoa.Funcionario.Funcao
{
    public class FuncaoFuncionarioImplementacao : BaseRepository<FuncaoFuncionarioEntity>, IFuncaoFuncionarioRepository
    {
        private readonly DbSet<FuncaoFuncionarioEntity> _dbSet;
        public FuncaoFuncionarioImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<FuncaoFuncionarioEntity>();
        }

        private IQueryable<FuncaoFuncionarioEntity> FullInclude(IQueryable<FuncaoFuncionarioEntity> query)
        {
            query = query.OrderBy(f => f.FuncaoFuncionario);

            return query;
        }
        public async Task<IEnumerable<FuncaoFuncionarioEntity>> GetAll()
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = FullInclude(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncaoFuncionarioEntity> GetById(Guid funcaoId)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = FullInclude(query);

                query = query.Where(f => f.Id == funcaoId);

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
