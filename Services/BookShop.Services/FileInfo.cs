namespace BookShop.Services
{
    public class FileInfo
    {
        public FileInfo(string url, string publicId)
        {
            this.Url = url;
            this.PublicId = publicId;
        }

        public string Url { get; }

        public string PublicId { get; }
    }
}
