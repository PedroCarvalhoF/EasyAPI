using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoa.Funcionario.Funcao;

public class FuncaoFuncionarioEntity : BaseEntity
{
    [Required]
    public string? FuncaoFuncionario { get; set; }
}

