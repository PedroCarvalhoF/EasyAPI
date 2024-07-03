namespace Easy.Services.DTOs.UserIdentity
{
    public class UsuarioLoginResponse
    {
        public bool sucesso => Erros.Count == 0;
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public List<string> Erros { get; set; }
        public UsuarioLoginResponse() => Erros = new List<string>();
        public UsuarioLoginResponse(bool sucesso, string accessToken, string refreshToken) : this()
        {
            this.accessToken = accessToken;
            this.refreshToken = refreshToken;
        }
        public void AdicionarErro(string erro) =>
            Erros.Add(erro);
        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
