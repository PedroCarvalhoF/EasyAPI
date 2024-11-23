using Microsoft.AspNetCore.Http;

namespace Easy.Services.DTOs.Produto;

public class ProdutoDtoUploadImageRequest
{
    public Guid Produtoid { get; private set; }
    public IFormFile IFormFile { get; private set; }
    public ProdutoDtoUploadImageRequest(Guid produtoid, IFormFile iFormFile)
    {
        Produtoid = produtoid;
        IFormFile = iFormFile;
    }
}
