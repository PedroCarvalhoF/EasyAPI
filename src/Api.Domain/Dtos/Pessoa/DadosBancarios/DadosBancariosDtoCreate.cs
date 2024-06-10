using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoas.DadosBancarios
{
    public class DadosBancariosDtoCreate
    {
        [Required(ErrorMessage = "Informe o Id da Pessoa")]
        public Guid PessoaId { get; set; }

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
    }
}
