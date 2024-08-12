namespace Easy.Services.DTOs.Email
{
    public class EmailDto
    {
        public EmailDto(string emailDestinatario, string assunto, string email)
        {
            EmailDestinatario = emailDestinatario;
            Assunto = assunto;
            Email = email;
        }

        public string EmailDestinatario { get; private set; }
        public string Assunto { get; private set; }
        public string Email { get; private set; }
    }
}
