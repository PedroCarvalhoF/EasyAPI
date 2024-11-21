using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.Produto;

public class ProdutoRepository : IProdutoRepository<ProdutoEntity, FiltroBase>
{
    private readonly MyContext _contexto;
    private DbSet<ProdutoEntity> _dbSet;

    public ProdutoRepository(MyContext contexto)
    {
        _dbSet = contexto.Set<ProdutoEntity>();
        _contexto = contexto;
    }
}
