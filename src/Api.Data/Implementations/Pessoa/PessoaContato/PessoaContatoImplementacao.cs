using Api.Data.Context;
using Data.Repository;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Interfaces.Repository.Pessoa.PessoaContato;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoas.PessoaContato
{
    public class PessoaContatoImplementacao : RepositoryGeneric<PessoaContatoEntity>, IPessoaContatoRepositoryGeneric
    {
        private readonly DbSet<PessoaContatoEntity> _dbSet;
        public PessoaContatoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<PessoaContatoEntity>();
        }

        private IQueryable<PessoaContatoEntity> FullInclude(IQueryable<PessoaContatoEntity> query)
        {

            query = query.Include(p => p.PessoaEntity);
            query = query.Include(p => p.ContatoEntity);

            return query;
        }

        public async Task<PessoaContatoEntity> GetPessoaContatoByPessoaId(Guid pessoaId)
        {
            try
            {
                IQueryable<PessoaContatoEntity> query = _dbSet.AsNoTracking();

                query = FullInclude(query);

                query = query.Where(p => p.PessoaEntityId == pessoaId);

                return await query.SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
