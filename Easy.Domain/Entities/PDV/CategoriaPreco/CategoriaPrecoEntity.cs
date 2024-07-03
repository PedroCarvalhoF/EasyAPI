using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.CategoriaPreco;

public class CategoriaPrecoEntity : BaseEntity
{
    public int Codigo { get; private set; }
    public string DescricaoCategoriaPreco { get; private set; }
    public bool Validada => Validar();

    public ICollection<PrecoProdutoEntity> PrecosProdutos { get; set; }
    public virtual ICollection<PedidoEntity> Pedidos { get; set; }
    private bool Validar()
    {
        if (DescricaoCategoriaPreco == null) return false;
        if (Codigo <= 0) return false;

        return true;
    }
    public CategoriaPrecoEntity() { }
    CategoriaPrecoEntity(int codigo, string descricaoCategoriaPreco, FiltroBase user) : base(user)
    {
        DomainValidation.When(string.IsNullOrEmpty(descricaoCategoriaPreco), "Informe a forma de pagamento.");
        DomainValidation.When(descricaoCategoriaPreco.Length > 50, "Descrição deve conter no máximo 50 caracteres.");

        DomainValidation.When(codigo <= 0, "Código não pode ser menor ou igual zero.");

        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }

    CategoriaPrecoEntity(Guid id, bool habilitado, int codigo, string descricaoCategoriaPreco, FiltroBase user) : base(id, habilitado, user)
    {
        DomainValidation.When(id == Guid.Empty, "Informe o id para realizar alteração");

        DomainValidation.When(string.IsNullOrEmpty(descricaoCategoriaPreco), "Informe a forma de pagamento.");
        DomainValidation.When(descricaoCategoriaPreco.Length > 50, "Descrição deve conter no máximo 50 caracteres.");

        DomainValidation.When(codigo <= 0, "Código não pode ser menor ou igual zero.");
        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }

    public static CategoriaPrecoEntity Create(int codigo, string descricaoCategoriaPreco, FiltroBase user)
        => new CategoriaPrecoEntity(codigo, descricaoCategoriaPreco, user);

    public static CategoriaPrecoEntity Update(Guid id, bool habilitado, int codigo, string descricaoCategoriaPreco, FiltroBase user)
        => new CategoriaPrecoEntity(id, habilitado, codigo, descricaoCategoriaPreco, user);

}
