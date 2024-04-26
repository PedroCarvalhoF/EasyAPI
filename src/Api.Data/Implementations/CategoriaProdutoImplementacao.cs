using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CategoriaProdutoImplementacao : BaseRepository<CategoriaProdutoEntity>, ICategoriaProdutoRepository
    {
        private readonly DbSet<CategoriaProdutoEntity> _dataset;

        public CategoriaProdutoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<CategoriaProdutoEntity>();
            _dataset.AsNoTracking();
        }
    }
}
