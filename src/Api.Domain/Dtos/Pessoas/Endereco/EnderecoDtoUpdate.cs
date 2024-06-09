using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoas.Endereco
{
    public class EnderecoDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(9)]
        public string? Cep { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Logradouro { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Numero { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Complemento { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Bairro { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Localidade { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Uf { get; set; }
        public string? Ibge { get; set; }
        public string? Gia { get; set; }
        public string? Ddd { get; set; }
        public string? Siafi { get; set; }
    }
}
