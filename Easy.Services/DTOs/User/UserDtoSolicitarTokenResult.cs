namespace Easy.Services.DTOs.User;

public class UserDtoSolicitarTokenResult
{
    public string Token { get; private set; }

    public UserDtoSolicitarTokenResult(string token)
    {
        Token = token;
    }
}
