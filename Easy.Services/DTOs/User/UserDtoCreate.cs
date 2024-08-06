namespace Easy.Services.DTOs.User;

public class UserDtoCreate
{

    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string SenhaConfirmacao { get; set; }

    //[Required(ErrorMessage = "O campo {0} é obrigatório")]
    //public string Nome { get; private set; }

    //[Required(ErrorMessage = "O campo {0} é obrigatório")]
    //public string SobreNome { get; private set; }


    //[Required(ErrorMessage = "O campo {0} é obrigatório")]
    //[EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    //public string Email { get; private set; }

    //[Required(ErrorMessage = "O campo {0} é obrigatório")]
    //[StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
    //public string Senha { get; private set; }

    //[Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
    //public string SenhaConfirmacao { get; private set; }
}
