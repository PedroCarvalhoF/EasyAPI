using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.FormaPagamento.Commands;

public class FormaPagamentoCreateCommand : IRequest<RequestResult>
{
    public FormaPagamentoCreateCommand(string descricaFormaPagamento, int codigo)
    {
        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
    }

    public string DescricaFormaPagamento { get; set; }
    public int Codigo { get; set; }
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}
