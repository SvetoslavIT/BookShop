namespace BookShop.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<IEnumerable<FileInfo>> UploadImageAsync(IEnumerable<IFormFile> files)
        {
            var urls = new List<FileInfo>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                await using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                await using var destinationStream = new MemoryStream(destinationImage);

                var uploadParams = new ImageUploadParams { File = new FileDescription(file.FileName, destinationStream) };
                var result = await this.cloudinary.UploadAsync(uploadParams);
                var fileInfo = new FileInfo(result.Url.AbsoluteUri, result.PublicId);
                urls.Add(fileInfo);
            }

            return urls;
        }

        public async Task RemoveImageAsync(string publicId)
        {
            var parameters = new DeletionParams(publicId);
            await this.cloudinary.DestroyAsync(parameters);
        }
    }
}
