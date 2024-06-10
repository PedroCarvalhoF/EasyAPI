using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoa.Funcionario.Funcao
{
    public class FuncaoFuncionarioDtoCreate
    {
        [Required]
        public string? FuncaoFuncionario { get; set; }
    }
}
