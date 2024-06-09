using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Entities.Pessoa.Pessoas;

namespace Domain.Entities.Pessoa.DadosBancarios
{
    public class DadosBancariosEntity : BaseEntity
    {
        [DisplayName("Nome do Banco")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? BancoSalario { get; set; }

        [DisplayName("Agencia")]
        [Required(ErrorMessage = "Informe a {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? Agencia { get; set; }

        [DisplayName("Conta Corrente com Digito")]
        [Required(ErrorMessage = "Informe a {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? ContaComDigito { get; set; }

        // Relacionamento com PessoaDadosBancariosEntity
        public IEnumerable<PessoaDadosBancariosEntity>? PessoaDadosBancarios { get; set; }
    }
}
