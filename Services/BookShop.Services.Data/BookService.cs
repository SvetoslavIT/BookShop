namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;
    using BookShop.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;
        private readonly IRepository<Publisher> publishersRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Author> authorsRepository;
        private readonly ICloudinaryService cloudinaryService;

        public BookService(
            IDeletableEntityRepository<Book> booksRepository,
            IRepository<Publisher> publishersRepository,
            IRepository<Category> categoriesRepository,
            IRepository<Author> authorsRepository,
            ICloudinaryService cloudinaryService)
        {
            this.booksRepository = booksRepository;
            this.publishersRepository = publishersRepository;
            this.categoriesRepository = categoriesRepository;
            this.authorsRepository = authorsRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<int> CreateBookAsync(AddBookViewModel model)
        {
            var publisher = await this.publishersRepository.All()
                .FirstOrDefaultAsync(x => x.Name == model.Name) ?? new Publisher { Name = model.Publisher };

            var filesInfo = await this.cloudinaryService.UploadImageAsync(model.Photos);
            var photos = filesInfo.Select(x => new Photo { Url = x.Url, PublicId = x.PublicId }).ToList();

            var book = new Book
            {
                Name = model.Name,
                Price = model.Price,
                Pages = model.Pages,
                Publisher = publisher,
                Photos = photos,
                Annotation = model.Annotation,
                Quantity = model.Quantity,
                Isbn = model.Isbn,
                Language = model.Language,
                YearOfIssue = model.YearOfIssue,
            };

            await this.AddCategoriesAsync(model, book);
            await this.AddAuthorsAsync(model, book);

            await this.booksRepository.AddAsync(book);
            await this.booksRepository.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> DoesBookExist(int id)
            => await this.booksRepository.AllAsNoTracking().AnyAsync(x => x.Id == id);

        public async Task<T> GetById<T>(int id)
            => await this.booksRepository.AllAsNoTracking()
                .Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();

        private async Task AddAuthorsAsync(AddBookViewModel model, Book book)
        {
            var authorNames = new HashSet<string>(model.Authors.Split(", "));
            foreach (var authorName in authorNames)
            {
                var author = await this.authorsRepository.All()
                    .FirstOrDefaultAsync(x => x.FullName == authorName) ?? new Author { FullName = authorName };

                book.AuthorBooks.Add(new AuthorBook { Author = author, Book = book });
            }
        }

        private async Task AddCategoriesAsync(AddBookViewModel model, Book book)
        {
            var categoryNames = new HashSet<string>(model.Categories.Split(", "));
            foreach (var categoryName in categoryNames)
            {
                var category = await this.categoriesRepository.All()
                    .FirstOrDefaultAsync(x => x.Name == categoryName) ?? new Category { Name = categoryName, };

                book.BookCategories.Add(new BookCategory { Book = book, Category = category });
            }
        }
    }
}
