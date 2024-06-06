using Api.Domain.Models;
using Domain.Enuns;

namespace Domain.Models.PessoaModels.PessoaModels
{
    public class PessoasModel : BaseModel
    {
        public string? NomeNomeFantasia { get; set; }
        public string? SobreNomeRazaoSocial { get; set; }
        public string? RgIE { get; set; }
        public string? CpfCnpj { get; set; }
        public DateTime? DataNascimentoFundacao { get; set; }
        public PessoaTipoEnum PessoaTipo { get; set; }
    }
}
