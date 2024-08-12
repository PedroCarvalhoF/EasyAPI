namespace Easy.Services.DTOs.User;

public class UserDtoHabilitarDesabilitarRequestResult
{
    public UserDtoHabilitarDesabilitarRequestResult(bool status, string mensagem)
    {
        Status = status;
        Mensagem = mensagem;
    }

    public bool Status { get; private set; }
    public string Mensagem { get; private set; }
}
