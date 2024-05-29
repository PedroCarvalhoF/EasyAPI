using Domain.Interfaces.Services.PDF;

namespace Service.Services.PDF
{
    public class PDFRepositoryFactory : IPDFRepositoryFactory
    {
        public IPDFRepository Create(string nomeArquivo, int tamanho)
        {
            return new PDFRepository(nomeArquivo, tamanho);
        }
    }
}
