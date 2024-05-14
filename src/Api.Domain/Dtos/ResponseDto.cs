using Api.Domain.Dtos.CategoriaPrecoDtos;
using System.Collections;

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
        public void CadastroOk(string titulo)
        {
            this.Status = true;
            this.Mensagem = $"{titulo}- Cadastro efetuado com sucesso";
        }
        public void CadastroOk(string titulo, string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"{titulo} - {detalhes}";
        }
        public void AlteracaoOk()
        {
            this.Status = true;
            this.Mensagem = $"Alteração realizada com sucesso";
        }
        public void AlteracaoOk(string titulo)
        {
            this.Status = true;
            this.Mensagem = $"{titulo} - Alteração realizada com sucesso";
        }
        public void AlteracaoOk(string titulo, string detalhes)
        {
            this.Status = true;
            this.Mensagem = $"{titulo} - {detalhes}";
        }
        public void ConsultaOk()
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso!";
        }
        public void ConsultaOk(int qtd)
        {
            this.Status = true;
            this.Mensagem = $"Consulta realizada com sucesso! Localizado(s) {qtd} registro(s).";
        }
        public void Erro()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação.";
        }

        public ResponseDto<T> Erro(Exception ex)
        {
            this.Status = false;
            this.Mensagem = $"Erro.Detalhes: {ex.Message}";
            return this;
        }
        public ResponseDto<T> Erro(string detalhes)
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar operação: {detalhes}";
            return this;
        }

        public void ErroConsulta()
        {
            this.Status = false;
            this.Mensagem = $"Não foi possivel realizar consulta";
        }
        public void ErroConsulta(string titulo)
        {
            this.Status = false;
            this.Mensagem = $"{titulo} Não foi possivel realizar consulta.";
        }

        public void ErroConsulta(string titulo, string detalhe)
        {
            this.Status = false;
            this.Mensagem = $"{titulo}: {detalhe}";
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
        public ResponseDto<T> Retorno(T dados)
        {
            this.Dados = dados;
            this.Status = true;
            if (dados is IList lista)
            {
                this.Mensagem = $"Sucesso- Número de registros: {lista.Count}";
            }
            else
            if (dados is T)
            {
                this.Mensagem = $"Sucesso:{1}";
            }
            return this;
        }

        public ResponseDto<T> EntitiesNull()
        {
            this.Status = false;
            this.Mensagem = "Não encontrado.";
            return this;
        }
    }
}
