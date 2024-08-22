using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces.Repository.PDV.Pdv;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.PDV;

public class PontoVendaRepository : BaseRepository<PontoVendaEntity, FiltroBase>, IPontoVendaRepository<PontoVendaEntity, FiltroBase>
{
    //protected readonly MyContext _context;
    private DbSet<PontoVendaEntity> _dataset;

    public PontoVendaRepository(MyContext context) : base(context)
    {
        //_context = context;
        _dataset = context.Set<PontoVendaEntity>();
    }

    public async Task<PontoVendaEntity> GetPdvById(Guid idPdv, FiltroBase filtro, bool includeAll = true)
    {
        try
        {
            IQueryable<PontoVendaEntity> query = _dataset.AsNoTracking();

            if (includeAll)
            {
                query = query.Include(user_gerente => user_gerente.UsuarioGerentePdv).ThenInclude(user => user.UserPdv);

                query = query.Include(user_operador => user_operador.UsuarioPdv).ThenInclude(user => user.UserPdv);

                query = query.Include(periodo => periodo.PeriodoPdv);

            }

            query = query.FiltroCliente(filtro);

            var result = await query.SingleOrDefaultAsync(t => t.Id == idPdv);
            return result ?? Activator.CreateInstance<PontoVendaEntity>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<PontoVendaEntity>> SelectAsync(PontoVendaQueryFilter pdvFiltro, FiltroBase filtro, bool includeAll = true)
    {
        try
        {
            IQueryable<PontoVendaEntity> query = _dataset.AsNoTracking();

            if (includeAll)
            {
                query = query.Include(user_gerente => user_gerente.UsuarioGerentePdv).ThenInclude(user => user!.UserPdv);

                query = query.Include(user_operador => user_operador.UsuarioPdv).ThenInclude(user => user!.UserPdv);

                query = query.Include(periodo => periodo.PeriodoPdv);

            }

            query = query.FiltroCliente(filtro);

            query = PontoVendaQueryFilter.FiltroPontoVenda(query, pdvFiltro);

            var result = await query.ToArrayAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
