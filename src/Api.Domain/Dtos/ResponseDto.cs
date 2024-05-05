namespace Domain.Dtos
{
    public class ResponseDto<T>
    {
        public bool Status { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }
    }
}
