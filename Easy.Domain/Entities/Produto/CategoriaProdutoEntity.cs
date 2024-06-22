using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.Produto;

public class CategoriaProdutoEntity : BaseEntity
{
    public string DescricaoCategoria { get; private set; }

    public CategoriaProdutoEntity() { }
    public CategoriaProdutoEntity(string descricaoCategoria, FiltroBase filtro) : base(filtro.clienteId, filtro.userId)
    {
        DomainValidation.When(string.IsNullOrEmpty(descricaoCategoria),
                              "Informe a descrição da categoria do produto");
        DomainValidation.When(descricaoCategoria.Length > 60,
                              "Descrição deve conter no máximo 60 caracteres");
        DescricaoCategoria = descricaoCategoria;
    }

    public CategoriaProdutoEntity(Guid id, bool habilitado, string descricaoCategoria, Guid clienteId, Guid userId) : base(id, habilitado, clienteId, userId)
    {
        DomainValidation.When(string.IsNullOrEmpty(descricaoCategoria),
                              "Informe a descrição da categoria do produto");
        DomainValidation.When(descricaoCategoria.Length > 60,
                              "Descrição deve conter no máximo 60 caracteres");
        DescricaoCategoria = descricaoCategoria;
    }
}
