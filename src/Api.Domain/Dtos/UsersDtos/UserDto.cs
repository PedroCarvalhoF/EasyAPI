namespace Domain.Dtos.UsersDtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Email { get; set; }
    }
}
