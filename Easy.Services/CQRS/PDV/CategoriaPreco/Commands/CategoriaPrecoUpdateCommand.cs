using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoUpdateCommand : IRequest<RequestResultForUpdate>
{
    public CategoriaPrecoUpdateCommand(int codigo, string descricaFormaPagamento, Guid id, bool habilitado)
    {
        Codigo = codigo;
        DescricaFormaPagamento = descricaFormaPagamento;
        Id = id;
        Habilitado = habilitado;
    }

    public Guid Id { get; private set; }
    public bool Habilitado { get; private set; }

    public int Codigo { get; private set; }
    public string DescricaFormaPagamento { get; private set; }


    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}
