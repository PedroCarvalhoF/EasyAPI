namespace Easy.Domain.Entities.PDV.FormaPagamento;

public class FormaPagamentoEntityFilter
{
    public Guid? FormaPagamentoId { get; set; }
    public bool? Habilitado { get; set; }
    public string? DescricaFormaPagamentoEquals { get; set; }
    public string? DescricaFormaPagamentoContains { get; set; }
    public int? Codigo { get; set; }
    public static IQueryable<FormaPagamentoEntity> QueryablePedidoEntity(IQueryable<FormaPagamentoEntity> query, FormaPagamentoEntityFilter filtro)
    {
        if (filtro.FormaPagamentoId != null && filtro.FormaPagamentoId != Guid.Empty)
            return query = query.Where(forma => forma.Id == filtro.FormaPagamentoId);
        else
        if (filtro.Codigo.HasValue)
            return query = query.Where(forma => forma.Codigo == filtro.Codigo);


        if (filtro.Habilitado.HasValue)
            query = query.Where(forma => forma.Habilitado == filtro.Habilitado);

        if (filtro.DescricaFormaPagamentoEquals != null)
            query = query.Where(forma => forma.DescricaFormaPagamento == filtro.DescricaFormaPagamentoEquals);
        else
            if (filtro.DescricaFormaPagamentoContains != null && filtro.DescricaFormaPagamentoContains != string.Empty)
            query = query.Where(forma => forma.DescricaFormaPagamento!.ToLower().Contains(filtro.DescricaFormaPagamentoContains.ToLower()));


        return query;
    }
}
