using Easy.Domain.Enuns;

namespace Easy.Services.DTOs.Produto;

public class ProdutoDtoUpdate
{
    public ProdutoDtoUpdate(Guid id, bool habilitado, string? nomeProduto, string? codigo, string? descricao, string? observacoes, string? imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum)
    {
        Id = id;
        Habilitado = habilitado;
        NomeProduto = nomeProduto;
        Codigo = codigo;
        Descricao = descricao;
        Observacoes = observacoes;
        ImagemUrl = imagemUrl;
        CategoriaProdutoEntityId = categoriaProdutoEntityId;
        MedidaProdutoEnum = medidaProdutoEnum;
        TipoProdutoEnum = tipoProdutoEnum;
    }

    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string? NomeProduto { get; set; }
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    public string? Observacoes { get; set; }
    public string? ImagemUrl { get; set; }
    public Guid CategoriaProdutoEntityId { get; set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get; set; }
    public ProdutoTipoEnum TipoProdutoEnum { get; set; }
}
