using Api.Domain.Entities;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.UserIdentity.Masters;

namespace Domain.Entities.FormaPagamento
{
    public class FormaPagamentoEntity : BaseEntity
    {
        public string DescricaoFormaPg { get; private set; }
        public bool Validada => Validar();

        private bool Validar()
        {
            return DescricaoFormaPg != null || DescricaoFormaPg != string.Empty;
        }

        public FormaPagamentoEntity() { }

        //cadastrar
        public FormaPagamentoEntity(FormaPagamentoDtoCreate create, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrWhiteSpace(create.DescricaoFormaPg))
                throw new ArgumentException("Descrição da forma de pagamento não pode ser vazia.");

            DescricaoFormaPg = create.DescricaoFormaPg!;
        }

        //update
        public FormaPagamentoEntity(FormaPagamentoDtoUpdate update, UserMasterUserDtoCreate users) : base(update.Id, update.Habilitado, users)
        {
            if (string.IsNullOrWhiteSpace(update.DescricaoFormaPg))
                throw new ArgumentException("Descrição da forma de pagamento não pode ser vazia.");

            DescricaoFormaPg = update.DescricaoFormaPg;
        }

    }
}