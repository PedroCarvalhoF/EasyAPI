using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CategoriaPreco;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CategoriaPrecoImplementacao : BaseRepository<CategoriaPrecoEntity>, ICategoriaPrecoRepository
    {
        private readonly DbSet<CategoriaPrecoEntity> _dataset;
        public CategoriaPrecoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<CategoriaPrecoEntity>();
        }


    }
}
