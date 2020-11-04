namespace BookShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<IEnumerable<FileInfo>> UploadImageAsync(IEnumerable<IFormFile> files);

        Task RemoveImageAsync(string publicId);
    }
}
