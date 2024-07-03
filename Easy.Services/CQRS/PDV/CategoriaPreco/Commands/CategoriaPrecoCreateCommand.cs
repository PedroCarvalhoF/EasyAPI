using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoCreateCommand : IRequest<RequestResult>
{
    public CategoriaPrecoCreateCommand(int codigo, string descricaFormaPagamento)
    {
        Codigo = codigo;
        DescricaFormaPagamento = descricaFormaPagamento;
    }

    public int Codigo { get; set; }
    public string DescricaFormaPagamento { get; set; }

    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}
