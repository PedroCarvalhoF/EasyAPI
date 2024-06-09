using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Enuns.Pessoas;
using Domain.Interfaces.Repository.PessoaRepositorys.Pessoa;
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
        private IQueryable<PessoaEntity> FullInclude(IQueryable<PessoaEntity> query)
        {
            query = query.Include(pessoa => pessoa.PessoaDadosBancarios)
                .ThenInclude(pessoaDadosBancarios => pessoaDadosBancarios.DadosBancariosEntity);

            query = query.Include(pessoa => pessoa.PessoaEnderecos)
                .ThenInclude(pessoaEndereco => pessoaEndereco.EnderecoEntity);

            return query;
        }
        public async Task<IEnumerable<PessoaEntity>> GetAll(bool include = false)
        {
            try
            {
                IQueryable<PessoaEntity> query = _dataset.AsNoTracking();

                if (include)
                {
                    query = FullInclude(query);
                }

                query = query.OrderBy(p => p.NomeNomeFantasia).ThenBy(p => p.SobreNomeRazaoSocial);

                var entities = await query.ToArrayAsync();

                return entities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<PessoaEntity> Get(Guid idPessoa, bool include = false)
        {
            try
            {
                IQueryable<PessoaEntity> query = _dataset.AsNoTracking();

                if (include)
                {
                    query = FullInclude(query);
                }

                query = query.OrderBy(p => p.NomeNomeFantasia).ThenBy(p => p.SobreNomeRazaoSocial);

                query = query.Where(p => p.Id == idPessoa);

                var entity = await query.SingleOrDefaultAsync();

                return entity;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PessoaEntity>> GetAllByPessoaTipo(PessoaTipoEnum pessoaTipo, bool include = false)
        {
            try
            {
                IQueryable<PessoaEntity> query = _dataset.AsNoTracking();

                if (include)
                {
                    query = FullInclude(query);
                }

                query = query.OrderBy(p => p.NomeNomeFantasia).ThenBy(p => p.SobreNomeRazaoSocial);

                query = query.Where(p => p.PessoaTipo == pessoaTipo);

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
