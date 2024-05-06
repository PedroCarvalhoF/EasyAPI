namespace Domain.Dtos
{
    public class ResponseDto<T>
    {
        public bool Status { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }

        public void CadastroOk()
        {
            this.Status = true;
            this.Mensagem = $"Cadastro efetuado com sucesso";
        }
        public void AlteracaoOk()
        {
            this.Status = true;
            this.Mensagem = $"Alteração realizada com sucesso";
        }

        public void ConsultaOk()
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso!";
        }

        public void ConsultaOk(int qtd)
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso! Localizados {qtd} registros.";
        }

        public void Error()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação.";
        }
        public void Error(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação: {detalhes}";
        }
    }
}
