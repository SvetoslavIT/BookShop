namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;
        private readonly IRepository<Publisher> publishersRepository;
        private readonly ICloudinaryService cloudinaryService;

        public BookService(
            IDeletableEntityRepository<Book> booksRepository,
            IRepository<Publisher> publishersRepository,
            ICloudinaryService cloudinaryService)
        {
            this.booksRepository = booksRepository;
            this.publishersRepository = publishersRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<int> CreateBookAsync(AddBookViewModel model)
        {
            var publisher = await this.publishersRepository.All()
                .FirstOrDefaultAsync(x => x.Name == model.Name);

            if (publisher == null)
            {
                publisher = new Publisher { Name = model.Publisher };
            }

            var filesInfo = await this.cloudinaryService.UploadImageAsync(model.Photos);
            var photos = new List<Photo>();

            foreach (var fileInfo in filesInfo)
            {
                photos.Add(new Photo { Url = fileInfo.Url, PublicId = fileInfo.PublicId });
            }

            var book = new Book
            {
                Name = model.Name,
                Price = model.Price,
                Pages = model.Pages,
                Publisher = publisher,
                Photos = photos,
            };

            await this.booksRepository.AddAsync(book);
            await this.booksRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}
