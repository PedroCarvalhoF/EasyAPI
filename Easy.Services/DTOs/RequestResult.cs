
namespace Easy.Services.DTOs
{
    public class RequestResult<T> where T : class
    {
        public bool Status { get; set; } = false;
        public int StatusCode { get; private set; } = 400;
        public string? Mensagem { get; private set; }
        public T? Data { get; private set; }

        RequestResult(T? data, string? mensagem)
        {
            Status = true;
            StatusCode = 200;

            if (string.IsNullOrEmpty(mensagem))
                Mensagem = "Requisição realizada com sucesso.";
            else
                Mensagem = mensagem;

            Data = data;
        }

        RequestResult(string? mensagem)
        {
            Status = false;
            StatusCode = 400;

            if (string.IsNullOrEmpty(mensagem))
                Mensagem = "Não foi possível relizar requisição.";
            else
                Mensagem = mensagem;
            Data = null;
        }


        public static RequestResult<T> Ok(T data = null, string? mensagem = "Requesição realizada com sucesso.")
        => new RequestResult<T>(data, mensagem);

        public static RequestResult<T> BadRequest(string? mensagem = "Não foi possível realizar requisição.")
        => new RequestResult<T>(mensagem);
    }
}
