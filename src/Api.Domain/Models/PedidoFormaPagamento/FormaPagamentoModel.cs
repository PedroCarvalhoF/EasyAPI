using Api.Domain.Models;

namespace Domain.Models.FormaPagamentoModels
{
    public class FormaPagamentoModel : ModelBase
    {
        private string? _descricaoFormaPg;

        public string DescricaoFormaPg
        {
            get
            {
                //AQUI VOLTA PRA PROGRAMA
                return _descricaoFormaPg.ToUpper();
            }
            set
            {
                //AQUI VAI PRO BANCO
                _descricaoFormaPg = value.ToLower()+" Luis";
            }
        }

    }
}
