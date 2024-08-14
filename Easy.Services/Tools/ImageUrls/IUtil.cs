using Microsoft.AspNetCore.Http;

namespace Easy.Services.Tools.ImageUrls
{
    public interface IUtil
    {
        Task<string> SaveImage(IFormFile imageFile, string destino);
        void DeleteImage(string imageName, string detino);
    }
}
