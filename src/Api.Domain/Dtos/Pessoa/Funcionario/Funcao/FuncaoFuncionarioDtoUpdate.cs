using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoa.Funcionario.Funcao
{
    public class FuncaoFuncionarioDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? FuncaoFuncionario { get; set; }
    }
}
