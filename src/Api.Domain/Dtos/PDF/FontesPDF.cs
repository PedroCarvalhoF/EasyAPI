using iTextSharp.text;

namespace Domain.Dtos.PDF
{
    public static class FontesPDF
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeArquivo">informe o nome do arquivo</param>
        /// <param name="tamanho">1- para bobina termica</param>
        /// <returns></returns>
        public static Font FontTitulo(int tamanhoDocumento)
        {
            Font titulo = FontFactory.GetFont("Arial", 18, Font.BOLD);

            switch (tamanhoDocumento)
            {
                case 1:
                    titulo = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    break;

                default:
                    break;
            }

            return titulo;
        }

        public static Font FontCelulaTabela(int tamanhoDocumento)
        {
            Font titulo = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            switch (tamanhoDocumento)
            {
                case 1:
                    titulo = FontFactory.GetFont("Arial", 8, Font.NORMAL);
                    break;

                default:
                    break;
            }

            return titulo;
        }
    }
}
