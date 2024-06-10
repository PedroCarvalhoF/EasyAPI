using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Repository.Pessoa.Funcionario.CTPS;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoa.Funcionario.CTPS
{
    public class CtpsImplementacao : BaseRepository<CtpsEntity>, ICtpsRepository
    {
        private readonly DbSet<CtpsEntity> _dbSet;
        public CtpsImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<CtpsEntity>();
        }
    }
}
