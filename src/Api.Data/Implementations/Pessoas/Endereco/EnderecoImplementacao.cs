using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Endereco;
using Domain.Interfaces.Repository.Pessoa.Endereco;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoas.Endereco
{
    public class EnderecoImplementacao : BaseRepository<EnderecoEntity>, IEnderecoRepository
    {
        private readonly DbSet<EnderecoEntity> _enderecoDbSet;
        public EnderecoImplementacao(MyContext context) : base(context)
        {
            _enderecoDbSet = context.Set<EnderecoEntity>();
        }

        private IQueryable<EnderecoEntity> FullInclude(IQueryable<EnderecoEntity> query)
        {
            return query;
        }

        public async Task<IEnumerable<EnderecoEntity>> GetAll(bool include)
        {
            try
            {
                IQueryable<EnderecoEntity> query = _enderecoDbSet.AsNoTracking();

                if (include)
                    query = FullInclude(query);

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
