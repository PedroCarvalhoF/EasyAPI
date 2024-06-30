using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.FormaPagamento;

public class FormaPagamentoEntity : BaseEntity
{
    public string DescricaFormaPagamento { get; set; }
    public int Codigo { get; set; }

    public bool Validada => Validar();

    private bool Validar()
    {
        if (DescricaFormaPagamento == null) return false;
        if (Codigo <= 0) return false;

        return true;
    }
    public FormaPagamentoEntity() { }
    FormaPagamentoEntity(string descricaFormaPagamento, int codigo, FiltroBase user) : base(user)
    {
        DomainValidation.When(string.IsNullOrEmpty(descricaFormaPagamento), "Informe a forma de pagamento.");
        DomainValidation.When(descricaFormaPagamento.Length > 50, "Descrição deve conter no máximo 50 caracteres.");

        DomainValidation.When(codigo <= 0, "Código não pode ser menor ou igual zero.");

        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
    }

    FormaPagamentoEntity(Guid id, bool habilitado, string descricaFormaPagamento, int codigo, FiltroBase user) : base(id, habilitado, user)
    {
        DomainValidation.When(id == Guid.Empty, "Informe o id para realizar alteração");

        DomainValidation.When(string.IsNullOrEmpty(descricaFormaPagamento), "Informe a forma de pagamento.");
        DomainValidation.When(descricaFormaPagamento.Length > 50, "Descrição deve conter no máximo 50 caracteres.");

        DomainValidation.When(codigo <= 0, "Código não pode ser menor ou igual zero.");

        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
    }

    public static FormaPagamentoEntity Create(string descricaFormaPagamento, int codigo, FiltroBase user)
        => new FormaPagamentoEntity(descricaFormaPagamento, codigo, user);

    public static FormaPagamentoEntity Update(Guid id, bool habilitado, string descricaFormaPagamento, int codigo, FiltroBase user)
       => new FormaPagamentoEntity(id, habilitado, descricaFormaPagamento, codigo, user);
}
