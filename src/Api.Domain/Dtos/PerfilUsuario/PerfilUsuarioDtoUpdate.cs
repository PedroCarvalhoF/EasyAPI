using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.PerfilUsuario
{
    public class PerfilUsuarioDtoUpdate
    {
        [Required(ErrorMessage = "Obrigatório Id Perfil para alterar")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres: {0}")]
        [DisplayName("Nome do Usuário")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe senha")]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }


    }
}
