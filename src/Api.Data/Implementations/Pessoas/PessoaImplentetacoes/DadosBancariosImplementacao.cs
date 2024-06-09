using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.DadosBancarios;
using Domain.Interfaces.Repository.Pessoa.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class DadosBancariosImplementacao : BaseRepository<DadosBancariosEntity>, IDadosBancariosRepository
    {
        private readonly DbSet<DadosBancariosEntity> _dataset;
        public DadosBancariosImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<DadosBancariosEntity>();
        }

        private IQueryable<DadosBancariosEntity> FullInclude(IQueryable<DadosBancariosEntity> query)
        {
            return query;
        }

        public async Task<IEnumerable<DadosBancariosEntity>> GetAll(bool include = false)
        {
            try
            {
                IQueryable<DadosBancariosEntity> query = _dataset.AsNoTracking();

                if (include)
                    query = FullInclude(query);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DadosBancariosEntity>> GetByAgencia(string agencia, bool include = false)
        {
            try
            {
                IQueryable<DadosBancariosEntity> query = _dataset.AsNoTracking();

                if (include)
                    query = FullInclude(query);

                query = query.Where(d => d.Agencia == agencia);

                return await query.ToArrayAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<DadosBancariosEntity> GetByContaCorrente(string contaComDigito, bool include = false)
        {
            try
            {
                IQueryable<DadosBancariosEntity> query = _dataset.AsNoTracking();

                if (include)
                    query = FullInclude(query);

                query = query.Where(d => d.ContaComDigito == contaComDigito);

                return await query.SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
