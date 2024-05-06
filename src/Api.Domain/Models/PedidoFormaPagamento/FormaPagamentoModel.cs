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
                return _descricaoFormaPg.ToUpper();
            }
            set
            {
                _descricaoFormaPg = value.ToLower();
            }
        }

    }
}
