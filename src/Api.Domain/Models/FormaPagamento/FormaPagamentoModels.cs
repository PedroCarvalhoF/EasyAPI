using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Models.FormaPagamentoModels
{
    public class FormaPagamentoModels
    {


        public void CadastrarFormaPagamento(string? descricaoFormaPg)
        {
            Id = Guid.NewGuid();
            DescricaoFormaPg = descricaoFormaPg;
            CreateAt = DateTime.Now;
            HabilitarFormaPagamento();
        }
        public void DesabilitarFormaPagamento()
        {
            this.Habilitado = false;
        }
        void HabilitarFormaPagamento()
        {
            this.Habilitado = true;
        }

        public void Alterar(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            this.Id = formaPagamentoDtoUpdate.Id;
            this.DescricaoFormaPg = formaPagamentoDtoUpdate?.DescricaoFormaPg;
            if (formaPagamentoDtoUpdate.Habilitado)
                HabilitarFormaPagamento();
            else
                DesabilitarFormaPagamento();
        }

        public Guid? Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public string? DescricaoFormaPg { get; private set; }
        public bool? Habilitado { get; private set; }
    }
}
