namespace Domain.Interfaces.Services.PDF
{
    public interface IPDFRepositoryFactory
    {
        IPDFRepository Create(string nomeArquivo, int tamanho);
    }
}
