using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Enuns;
using Easy.Domain.Tools;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.Produto;

public class ProdutoEntity : BaseEntity
{
    public string NomeProduto { get; private set; }
    public string Codigo { get; private set; }
    public string? Descricao { get; private set; }
    public string? Observacoes { get; private set; }
    public string? ImagemUrl { get; private set; }
    public Guid CategoriaProdutoEntityId { get; private set; }
    public virtual CategoriaProdutoEntity? CategoriaProdutoEntity { get; private set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get; private set; }
    public ProdutoTipoEnum TipoProdutoEnum { get; private set; }

    public ProdutoEntity() { }
    //create
    ProdutoEntity(string nomeProduto, string codigo, string descricao, string observacoes, string imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum, FiltroBase users) : base(users)
    {

        DomainValidation.When(string.IsNullOrWhiteSpace(nomeProduto), "Informe nome do produto.");
        DomainValidation.When(nomeProduto.Length > 100, "Nome do produto muito extenso. Máximo 100 caracteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(codigo), "Informe o código do produto.");
        DomainValidation.When(codigo.Length > 100, "Código muito extenso. Máximo 100 caracteres");

        if (descricao != null)
            DomainValidation.When(descricao.Length > 100, "Descrição muito extensa. Máximo 100 caracteres");

        if (observacoes != null)
            DomainValidation.When(observacoes.Length > 100, "Descrição muito extensa. Máximo 100 caracteres");

        DomainValidation.When(categoriaProdutoEntityId == Guid.Empty, "Informe a categoria do produto");

        DomainValidation.When(medidaProdutoEnum <= 0, "Informe a medida do produto");

        DomainValidation.When(tipoProdutoEnum <= 0, "Informe o tipo do produto");

        NomeProduto = PrimeiraLetraSempreMaiuscula.Formatar(nomeProduto);
        Codigo = codigo;
        Descricao = descricao;
        Observacoes = observacoes;
        ImagemUrl = imagemUrl;
        CategoriaProdutoEntityId = categoriaProdutoEntityId;
        MedidaProdutoEnum = medidaProdutoEnum;
        TipoProdutoEnum = tipoProdutoEnum;
    }
    //update
    ProdutoEntity(Guid id, bool habilitado, string nomeProduto, string codigo, string descricao, string observacoes, string imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum, FiltroBase users) : base(id, habilitado, users)
    {
        DomainValidation.When(id == Guid.Empty, "Informe o id");

        DomainValidation.When(string.IsNullOrWhiteSpace(nomeProduto), "Informe nome do produto.");
        DomainValidation.When(nomeProduto.Length > 100, "Nome do produto muito extenso. Máximo 100 caracteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(codigo), "Informe o código do produto.");
        DomainValidation.When(codigo.Length > 100, "Código muito extenso. Máximo 100 caracteres");

        DomainValidation.When(descricao.Length > 100, "Descrição muito extensa. Máximo 100 caracteres");

        DomainValidation.When(observacoes.Length > 100, "Descrição muito extensa. Máximo 100 caracteres");

        DomainValidation.When(categoriaProdutoEntityId == Guid.Empty, "Informe a categoria do produto");

        DomainValidation.When(medidaProdutoEnum <= 0, "Informe a medida do produto");

        DomainValidation.When(tipoProdutoEnum <= 0, "Informe o tipo do produto");

        NomeProduto = PrimeiraLetraSempreMaiuscula.Formatar(nomeProduto);
        Codigo = codigo;
        Descricao = descricao;
        Observacoes = observacoes;
        ImagemUrl = imagemUrl;
        CategoriaProdutoEntityId = categoriaProdutoEntityId;
        MedidaProdutoEnum = medidaProdutoEnum;
        TipoProdutoEnum = tipoProdutoEnum;
    }

    public static ProdutoEntity Create(string nomeProduto, string codigo, string descricao, string observacoes, string imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum, FiltroBase users)
        => new ProdutoEntity(nomeProduto, codigo, descricao, observacoes, imagemUrl, categoriaProdutoEntityId, medidaProdutoEnum, tipoProdutoEnum, users);

    public static ProdutoEntity Update(Guid id, bool habilitado, string nomeProduto, string codigo, string descricao, string observacoes, string imagemUrl, Guid categoriaProdutoEntityId, MedidaProdutoEnum medidaProdutoEnum, ProdutoTipoEnum tipoProdutoEnum, FiltroBase users)
       => new ProdutoEntity(id, habilitado, nomeProduto, codigo, descricao, observacoes, imagemUrl, categoriaProdutoEntityId, medidaProdutoEnum, tipoProdutoEnum, users);
}
