using System.Collections;

namespace Domain.Dtos
{
    public class ResponseDto<T>
    {
        public bool Status { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }

        public ResponseDto<T> CadastroOk()
        {
            this.Status = true;
            this.Mensagem = $"Cadastro efetuado com sucesso.";
            return this;
        }
        public ResponseDto<T> CadastroOk(string titulo)
        {
            this.Status = true;
            this.Mensagem = $"{titulo}.";
            return this;
        }
        public void CadastroOk(string titulo, string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"{titulo} - {detalhes}";
        }
        public ResponseDto<T> AlteracaoOk()
        {
            this.Status = true;
            this.Mensagem = $"Alteração realizada com sucesso.";
            return this;
        }
        public ResponseDto<T> AlteracaoOk(string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"Alteração: {detalhes}";
            return this;
        }
        public void AlteracaoOk(string titulo, string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"{titulo} - {detalhes}.";
        }
        public ResponseDto<T> ConsultaOk()
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso!";
            return this;
        }
        public void ConsultaOk(int qtd)
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso! Localizado(s) {qtd} registro(s).";
        }
        public ResponseDto<T> Erro()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação.";
            return this;
        }

        public ResponseDto<T> Erro(DivideByZeroException ex)
        {
            this.Status = true;
            this.Mensagem = $"Não foi possível realizar calculo.";
            return this;
        }
        public ResponseDto<T> Erro(Exception ex)
        {
            this.Status = false;
            this.Mensagem = $"Erro.Detalhes: {ex.Message}.";
            return this;
        }
        public ResponseDto<T> Erro(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação: {detalhes}.";
            return this;
        }

        public void ErroConsulta()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar consulta.";
        }
        public ResponseDto<T> ErroConsulta(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"{detalhes}.";
            return this;
        }

        public void ErroConsulta(string titulo, string detalhe)
        {
            this.Status = false;
            this.Mensagem = $"{titulo}: {detalhe} .";
        }

        public ResponseDto<T> ErroCadastro()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar cadastro.";
            return this;
        }

        public ResponseDto<T> ErroUpdate()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar alteração.";
            return this;
        }

        public ResponseDto<T> ErroUpdate(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar alteração.Detalhes: {detalhes}";
            return this;
        }

        public void ErroCadastro(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Erro.Detalhes: {detalhes} .";
        }
        public ResponseDto<T> Retorno(T dados)
        {
            this.Dados = dados;
            this.Status = true;
            if (dados is IList lista)
            {
                this.Mensagem = $"Total Registro: {lista.Count} .";
            }
            else
            if (dados is T)
            {
                this.Mensagem = $"Sucesso:{1} .";
            }
            return this;
        }

        public ResponseDto<T> EntitiesNull()
        {
            this.Status = false;
            this.Mensagem = "Nenhum registro encontrado.";
            return this;
        }

        public ResponseDto<T> UpdateOk()
        {
            this.Status = true;
            this.Mensagem = $"Alteração realizada com sucesso.";
            return this;
        }

        public ResponseDto<T> DeleteOK(string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"detalhes";
            return this;
        }
    }
}
