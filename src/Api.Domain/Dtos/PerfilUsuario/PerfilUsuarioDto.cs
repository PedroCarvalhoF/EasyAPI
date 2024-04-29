namespace Domain.Dtos.PerfilUsuario
{
    public class PerfilUsuarioDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }             
        public string? Nome { get; set; }
        public string? Senha { get; set; }
    }
}
