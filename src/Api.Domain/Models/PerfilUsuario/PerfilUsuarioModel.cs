namespace Domain.Models.PerfilUsuario
{
    public class PerfilUsuarioModel
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public Guid IdentityId { get; set; }
        public string? Nome { get; set; }
    }
}
