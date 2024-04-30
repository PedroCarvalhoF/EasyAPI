namespace Domain.Models.PessoaModels.PessoaModels
{
    public class PessoasModel
    {
        public Guid Id { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? SegundoNome { get; set; }
        public string? RgIE { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Sexo { get; set; }
        public DateTime DataNascimentoFundacao { get; set; }
        public Guid? PessoaTipoEntityId { get; set; }


        public PessoasModel(string? primeiroNome, string? segundoNome, string? rgie, string? cpfcnpj, string? sexo, DateTime dataNascimentoFundacao, Guid? pessoaTipoEntityId)
        {

            PrimeiroNome = FormartarNome(primeiroNome);
            SegundoNome = segundoNome;
            Sexo = sexo;
            DataNascimentoFundacao = dataNascimentoFundacao;
            PessoaTipoEntityId = pessoaTipoEntityId;
            RgIE = rgie;
            CpfCnpj = cpfcnpj;

        }

        public PessoasModel(Guid idPessoa, string? primeiroNome, string? segundoNome, string? rgie, string? cpfcnpj, string? sexo, DateTime dataNascimentoFundacao, Guid? pessoaTipoEntityId)
        {
            Id = idPessoa;
            PrimeiroNome = FormartarNome(primeiroNome);
            SegundoNome = segundoNome;
            Sexo = sexo;
            DataNascimentoFundacao = dataNascimentoFundacao;
            PessoaTipoEntityId = pessoaTipoEntityId;
            RgIE = rgie;
            CpfCnpj = cpfcnpj;

        }

        private string? FormartarNome(string? nome)
        {
            if (string.IsNullOrEmpty(nome))
                return nome;

            string[] partes = nome.Split(' ');

            for (int i = 0; i < partes.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(partes[i]))
                {
                    if (i > 0 && IsExcecao(partes[i]))
                    {
                        partes[i] = partes[i].ToLower();
                    }
                    else
                    {
                        partes[i] = partes[i][0].ToString().ToUpper() + partes[i].Substring(1).ToLower();
                    }
                }
            }

            return string.Join(" ", partes);
        }
        private bool IsExcecao(string palavra)
        {
            // Adicione aqui qualquer lógica para identificar exceções
            // Por exemplo, verificar se a palavra é uma sigla
            return palavra.Length <= 2; // Exemplo: considera como exceção palavras com duas letras ou menos
        }


    }
}
