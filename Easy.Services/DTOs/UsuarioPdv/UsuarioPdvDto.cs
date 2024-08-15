namespace Easy.Services.DTOs.UsuarioPdv
{
    public class UsuarioPdvDto
    {
        public Guid UserPdvId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Habilitado { get; private set; }

        public string MensagemStatus => ValidarDto();

        private string ValidarDto()
        {
            if (Habilitado)
                return "Usuário habilitado para utilizar caixa.";

            return "Usuário não tem permissão para acessar caixa.";
        }

        public UsuarioPdvDto(Guid userPdvId, string nome, string email, bool habilitado)
        {
            UserPdvId = userPdvId;
            Nome = nome;
            Email = email;
            Habilitado = habilitado;
        }
    }
}
