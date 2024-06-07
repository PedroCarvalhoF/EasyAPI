using Domain.Enuns.Pessoas;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PessoasDtos.PessoaDtos
{
    public class PessoaDtoUpdate
    {
        [DisplayName("Informe o Id")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid Id { get; set; }

        [DisplayName("Nome ou Nome Fantasia")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? NomeNomeFantasia { get; set; }

        [DisplayName("Sobre nome ou Razão Social")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(100, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? SobreNomeRazaoSocial { get; set; }

        [DisplayName("Rg ou Inscrição Estadual")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? RgIE { get; set; }

        [DisplayName("Cpf ou CNPJ")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(50, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? CpfCnpj { get; set; }

        [DisplayName("Data Nascimento ou Fundação")]
        [Required(ErrorMessage = "Informe a {0}")]
        public DateTime? DataNascimentoFundacao { get; set; }

        [DisplayName("Tipo de Pessoa")]
        [Required(ErrorMessage = "Informe o {0}")]
        public PessoaTipoEnum PessoaTipo { get; set; }
    }
}
