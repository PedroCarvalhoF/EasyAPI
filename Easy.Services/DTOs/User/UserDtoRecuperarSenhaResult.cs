namespace Easy.Services.DTOs.User
{
    public class UserDtoRecuperarSenhaResult
    {
        public UserDtoRecuperarSenhaResult(bool status)
        {
            Status = status;
            if (status)
                Mensagem = "Senha alterada";
            else
                Mensagem = "Não foi possível alterar senha";
        }

        public bool Status { get; private set; }
        public string Mensagem { get; private set; }
    }
}
