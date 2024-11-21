using Easy.Domain.Enuns;

namespace Easy.Services.DTOs.Produto;

public class ProdutoDtoCreate
{
    public string NomeProduto { get; private set; }
    public string Codigo { get; private set; }
    public string? Descricao { get; private set; }
    public string? Observacoes { get; private set; }
    public string? ImagemUrl { get; private set; }
    public Guid CategoriaProdutoEntityId { get; private set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get; private set; }
    public ProdutoTipoEnum TipoProdutoEnum { get; private set; }
    public ProdutoDtoCreate(string nomeProduto, string codigo, string? descricao, string? observacoes, string? imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum)
    {
        NomeProduto = nomeProduto;
        Codigo = codigo;
        Descricao = descricao;
        Observacoes = observacoes;
        ImagemUrl = imagemUrl;
        CategoriaProdutoEntityId = categoriaProdutoEntityId;
        MedidaProdutoEnum = medidaProdutoEnum;
        TipoProdutoEnum = tipoProdutoEnum;
    }
}
