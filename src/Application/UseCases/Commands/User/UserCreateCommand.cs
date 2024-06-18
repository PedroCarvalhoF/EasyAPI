using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Commands.User
{
    public class UserCreateCommand : ICommand
    {
        public UserCreateCommand(string nome, string sobreNome, string email, string senha, string senhaConfirmacao)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Senha = senha;
            SenhaConfirmacao = senhaConfirmacao;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SobreNome { get; private set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; private set; }

        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
        public string SenhaConfirmacao { get; private set; }
    }
}
