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
    }
}
