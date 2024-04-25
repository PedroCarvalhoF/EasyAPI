using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Repository.PessoaRepositorys.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class PessoaImplementacao : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        private readonly DbSet<PessoaEntity> _dataset;
        public PessoaImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PessoaEntity>();
        }

        public async Task<PessoaEntity> Get(Guid idPessoa, bool include = true)
        {

            return null;

            //IQueryable<PessoaEntity>? query = _context.Pessoas?.AsNoTracking();

            //query = Query(query, include);

            //query = query.Where(p => p.Id.Equals(idPessoa));

            //PessoaEntity? entity = await query.SingleOrDefaultAsync();

            //return entity;
        }

        public async Task<IEnumerable<PessoaEntity>> GetAll(bool include = true)
        {
            return null;
            //IQueryable<PessoaEntity>? query = _context.Pessoas?.AsNoTracking();

            //query = Query(query, include);

            //PessoaEntity[] entities = await query.ToArrayAsync();

            //return entities;
        }

        public async Task<IEnumerable<PessoaEntity>> GetAll(Guid pessoaTipo, bool include = true)
        {
            return null;
            //IQueryable<PessoaEntity>? query = _context.Pessoas?.AsNoTracking();

            //query = Query(query, include);

            //query = query?.Where(ps => ps.PessoaTipoEntity.Id.Equals(pessoaTipo));

            //PessoaEntity[] entities = await query?.ToArrayAsync();

            //return entities;
        }


        private static IQueryable<PessoaEntity> Query(IQueryable<PessoaEntity>? query, bool include = true)
        {
            query = query.AsNoTracking();

            if (include)
            {
                query = query.Include(pt => pt.PessoaTipoEntity);
            }

            return query;
        }
    }
}
