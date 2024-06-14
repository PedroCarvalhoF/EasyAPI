using Api.Domain.Entities;

namespace Domain.Entities.FormaPagamento
{
    public class FormaPagamentoEntity : BaseEntity
    {
        public string DescricaoFormaPg { get; private set; }

        public FormaPagamentoEntity() { }

        public FormaPagamentoEntity(string descricaoFormaPg, Guid? userMasterClienteIdentityId, Guid? userId) : base(userMasterClienteIdentityId, userId)
        {
            if (string.IsNullOrWhiteSpace(descricaoFormaPg))
                throw new ArgumentException("Descrição da forma de pagamento não pode ser vazia.");

            DescricaoFormaPg = descricaoFormaPg;
        }

        public void AtualizarDescricao(string novaDescricao)
        {
            if (string.IsNullOrWhiteSpace(novaDescricao))
                throw new ArgumentException("Nova descrição não pode ser vazia.");

            DescricaoFormaPg = novaDescricao;
            UpdateTimestamp();
        }

        public void DesabilitarFormaPagamento()
        {
            Desabilitar();
        }

        public void HabilitarFormaPagamento()
        {
            Habilitar();
        }
    }
}