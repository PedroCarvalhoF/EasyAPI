using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.FormaPagamento
{
    public class FormaPagamentoEntity : BaseEntity
    {
        public string? DescricaFormaPagamento { get; private set; }
        public int Codigo { get; private set; }
        public virtual ICollection<PagamentoPedidoEntity>? Pagamentos { get; private set; } = null;

        public bool Validada => Validar();

        #region Construtores
        private FormaPagamentoEntity() { }

        private FormaPagamentoEntity(string descricaFormaPagamento, int codigo, FiltroBase user) : base(user)
        {
            ValidateFields(descricaFormaPagamento, codigo);
            DescricaFormaPagamento = descricaFormaPagamento;
            Codigo = codigo;
        }

        private FormaPagamentoEntity(Guid id, bool habilitado, string descricaFormaPagamento, int codigo, FiltroBase user)
            : base(id, habilitado, user)
        {
            if (id == Guid.Empty)
                DomainValidation.When(true, "Informe o id para realizar alteração");

            ValidateFields(descricaFormaPagamento, codigo);
            DescricaFormaPagamento = descricaFormaPagamento;
            Codigo = codigo;
        }

        public static FormaPagamentoEntity Create(string descricaFormaPagamento, int codigo, FiltroBase user)
            => new FormaPagamentoEntity(descricaFormaPagamento, codigo, user);

        public static FormaPagamentoEntity Update(Guid id, bool habilitado, string descricaFormaPagamento, int codigo, FiltroBase user)
            => new FormaPagamentoEntity(id, habilitado, descricaFormaPagamento, codigo, user);
        #endregion
        #region Validações
        private void ValidateFields(string descricaFormaPagamento, int codigo)
        {
            DomainValidation.When(string.IsNullOrEmpty(descricaFormaPagamento), "Informe a forma de pagamento.");
            DomainValidation.When(descricaFormaPagamento.Length > 50, "Descrição deve conter no máximo 50 caracteres.");
            DomainValidation.When(codigo <= 0, "Código não pode ser menor ou igual zero.");
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(DescricaFormaPagamento) && Codigo > 0;
        }
        #endregion
    }
}
