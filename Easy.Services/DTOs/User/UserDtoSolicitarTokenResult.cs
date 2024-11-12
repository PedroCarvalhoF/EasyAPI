namespace Easy.Services.DTOs.User;

public class UserDtoSolicitarTokenResult
{
    public string Token { get; private set; }

    public UserDtoSolicitarTokenResult()
    {
        Token = "Token criado com sucesso. Verifique sua caixa de e-mail";
    }
}
