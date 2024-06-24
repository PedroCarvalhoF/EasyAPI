using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.Produto.CategoriaProduto;

public class CategoriaProdutoEntity : BaseEntity
{
    public string DescricaoCategoria { get; private set; }
    public bool Validada => Validar();
    public virtual ICollection<ProdutoEntity> Produtos { get; set; }
    private bool Validar()
    {
        if (DescricaoCategoria.Length > 50)
            return false;
        if (string.IsNullOrWhiteSpace(DescricaoCategoria))
            return false;
        return true;
    }

    public CategoriaProdutoEntity() { }
    CategoriaProdutoEntity(string descricaoCategoria, FiltroBase users) : base(users)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(descricaoCategoria), "Informe a descrição da categoria.");
        DomainValidation.When(descricaoCategoria.Length > 50, "Descrição não pode passar de 50 caracteres. ");
        DescricaoCategoria = descricaoCategoria;
    }

    CategoriaProdutoEntity(Guid id, bool habilitado, string descricaoCategoria, FiltroBase users) : base(id, habilitado, users)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(descricaoCategoria), "Informe a descrição da categoria.");
        DomainValidation.When(descricaoCategoria.Length > 50, "Descrição não pode passar de 50 caracteres. ");
        DescricaoCategoria = descricaoCategoria;
    }

    public static CategoriaProdutoEntity Create(string descricaoCategoria, FiltroBase users)
        => new CategoriaProdutoEntity(descricaoCategoria, users);

    public static CategoriaProdutoEntity Update(Guid id, bool habilitado, string descricaoCategoria, FiltroBase users)
       => new CategoriaProdutoEntity(descricaoCategoria, users);
}