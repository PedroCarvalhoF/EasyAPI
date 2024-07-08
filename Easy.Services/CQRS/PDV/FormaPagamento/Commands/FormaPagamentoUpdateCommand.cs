using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoUpdateCommand : IRequest<RequestResultForUpdate>
{
    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string DescricaFormaPagamento { get; set; }
    public int Codigo { get; set; }
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}
