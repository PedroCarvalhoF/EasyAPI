using Api.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.UsuarioSistema
{
    public class PerfilUsuarioEntity : BaseEntity
    {
        
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres: {0}")]
        [DisplayName("Nome do Usuário")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "Informe senha")]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }        

    }
}
