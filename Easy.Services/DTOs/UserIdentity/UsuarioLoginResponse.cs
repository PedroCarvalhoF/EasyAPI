namespace Easy.Services.DTOs.UserIdentity;

public class UsuarioLoginResponse
{
    public bool sucesso => Erros.Count == 0;
    public List<string> Erros { get; set; }
    public Guid IdUser { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string accessToken { get; set; }
    public string refreshToken { get; set; }

    public UsuarioLoginResponse() => Erros = new List<string>();
    public UsuarioLoginResponse(bool sucesso, string accessToken, string refreshToken) : this()
    {
        this.accessToken = accessToken;
        this.refreshToken = refreshToken;
    }

    public void UsuarioReponseDetails(string nome, string email, Guid idUser)
    {
        Nome = nome;
        Email = email;
        IdUser = idUser;
    }
    public void AdicionarErro(string erro) =>
        Erros.Add(erro);
    public void AdicionarErros(IEnumerable<string> erros) =>
        Erros.AddRange(erros);
}
