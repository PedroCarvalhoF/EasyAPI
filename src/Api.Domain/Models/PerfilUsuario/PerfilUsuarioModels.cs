namespace Domain.Models.PerfilUsuario
{
    public class PerfilUsuarioModels
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }       
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmarSenha { get; set; }
    }
}
