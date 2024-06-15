using System.Globalization;

namespace Domain.Helpers.Tools
{
    public static class PrimeiraLetraSempreMaiuscula
    {
        public static string Formatar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;

            var palavras = texto.Split(' ');
            for (int i = 0; i < palavras.Length; i++)
            {
                if (palavras[i].Length > 3)
                {
                    palavras[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavras[i].ToLower());
                }
                else
                {
                    palavras[i] = palavras[i].ToLower();
                }
            }
            return string.Join(' ', palavras);
        }
    }
}
