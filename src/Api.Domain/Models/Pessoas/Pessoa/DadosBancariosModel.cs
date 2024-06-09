using Api.Domain.Models;
using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Models.Pessoas.Pessoa
{
    public class DadosBancariosModel : BaseModel
    {
        public string? BancoSalario { get; set; }
        public string? Agencia { get; set; }
        public string? ContaComDigito { get; set; }
        public IEnumerable<PessoaDadosBancariosEntity>? PessoaDadosBancarios { get; set; }
    }
}
