using Easy.Domain.Entities;
using Easy.Domain.Enuns;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoCreateCommand : IRequest<RequestResult>
{       
    public string NomeProduto { get;  set; }
    public string Codigo { get;  set; }
    public string? Descricao { get;  set; }
    public string? Observacoes { get;  set; }
    public string? ImagemUrl { get;  set; }
    public Guid CategoriaProdutoEntityId { get;  set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get;  set; }
    public ProdutoTipoEnum TipoProdutoEnum { get;  set; }


    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}
