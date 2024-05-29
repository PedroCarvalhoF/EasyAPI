using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Domain.Interfaces.Services.PDF
{
    public interface IPDFRepository
    {
        void Initialize(string nomeArquivo, int tamanho);
        Document CriarPDF(string nomeArquivo, int tamanho);
        Document GetDocumentPdf();
        void AdicinarTitulo(string titulo, Font font = null);
        PdfPTable CriarTabela(int qtd_colunas);
        PdfPCell CriarCelulaTabela(string textoCelula, int horizontalAlignment = 0, int verticalAlingnment = 1, Font fonteCelula = null);
        PdfPTable AdicinarCelulaTabela(PdfPCell celula, PdfPTable tabela);
        void DivPDF();
    }
}
