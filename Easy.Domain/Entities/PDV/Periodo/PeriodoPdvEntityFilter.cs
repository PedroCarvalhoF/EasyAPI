namespace Easy.Domain.Entities.PDV.Periodo
{
    public class PeriodoPdvEntityFilter
    {
        public Guid? Id { get; set; } = null;
        public bool? Habilitado { get; set; } = null;
        public string? DescricaoPeriodoEquals { get; set; } = null;
        public string? DescricaoPeriodoContains { get; set; } = null;

        public static IQueryable<PeriodoPdvEntity> QueryableEntity(IQueryable<PeriodoPdvEntity> query, PeriodoPdvEntityFilter filtro)
        {
            if (filtro.Id != null && filtro.Id != Guid.Empty)
                return query = query.Where(pr => pr.Id.Equals(filtro.Id));

            if (filtro.Habilitado.HasValue)
                query = query.Where(pr => pr.Habilitado == filtro.Habilitado);

            if (!string.IsNullOrEmpty(filtro.DescricaoPeriodoEquals))
                query = query.Where(pr => pr.DescricaoPeriodo == filtro.DescricaoPeriodoEquals);
            else

            if (!string.IsNullOrEmpty(filtro.DescricaoPeriodoContains))
                query = query.Where(pr => pr.DescricaoPeriodo!.ToLower().Contains(filtro.DescricaoPeriodoContains.ToLower()));


            return query;
        }
    }
}
