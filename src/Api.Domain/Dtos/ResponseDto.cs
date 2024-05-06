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

        public void Erro()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação.";
        }
        public void Erro(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação: {detalhes}";
        }

        public void ErroConsulta()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação.";
        }

        public void ErroCadastro()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar cadastro.";
        }

        public void ErroUpdate()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar update.";
        }

        public void ErroCadastro(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Erro.Detalhes: {detalhes}";
        }
    }
}
