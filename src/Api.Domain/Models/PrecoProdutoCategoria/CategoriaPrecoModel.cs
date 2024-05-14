namespace Api.Domain.Models.CategoriaPreco
{
    public class CategoriaPrecoModel : ModelBase
    {
        private string? _descricaoCategoria;

        public string? DescricaoCategoria
        {
            get { return PrimeiraLetraMaiuscula(_descricaoCategoria); }
            set { _descricaoCategoria = value; }
        }

        public string PrimeiraLetraMaiuscula(string? texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            // Converte a primeira letra para maiúscula e mantém o restante da string inalterada
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }
    }
}