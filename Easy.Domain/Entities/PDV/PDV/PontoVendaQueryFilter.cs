namespace Easy.Domain.Entities.PDV.PDV;

public class PontoVendaQueryFilter
{
    public Guid? IdPdv { get; set; }
    public Guid? UsuarioGerentePdvId { get; set; }
    public Guid? UsuarioPdvId { get; set; }
    public bool? Aberto { get; set; }
    public Guid? PeriodoPdvId { get; set; }
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }

    public static IQueryable<PontoVendaEntity> FiltroPontoVenda(IQueryable<PontoVendaEntity> query, PontoVendaQueryFilter filter)
    {

        if (filter.UsuarioGerentePdvId.HasValue)
        {
            query = query.Where(pv => pv.UsuarioGerentePdvId == filter.UsuarioGerentePdvId.Value);
        }

        if (filter.UsuarioPdvId.HasValue)
        {
            query = query.Where(pv => pv.UsuarioPdvId == filter.UsuarioPdvId.Value);
        }

        //if (filter.Aberto.HasValue)
        //{
        //    query = query.Where(pv => pv.Aberto == filter.Aberto.Value);
        //}

        if (filter.PeriodoPdvId.HasValue)
        {
            query = query.Where(pv => pv.PeriodoPdvId == filter.PeriodoPdvId.Value);
        }

        if (filter.DataInicial.HasValue && filter.DataFinal.HasValue)
        {
            DateTime dataInicial = filter.DataInicial.Value.Date;
            DateTime dataFinal = filter.DataFinal.Value.Date;

            query = query.Where(pv => pv.CreateAt.Date >= dataInicial && pv.CreateAt.Date <= dataFinal);
        }


        return query;
    }
}


