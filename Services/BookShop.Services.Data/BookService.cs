namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;
    using BookShop.Services.Mapping;
    using BookShop.Common;
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

            var book = AutoMapperConfig.MapperInstance.Map<Book>(model);
            book.Publisher = publisher;
            book.Photos = photos;

            await this.AddCategoriesAsync(model, book);
            await this.AddAuthorsAsync(model, book);

            await this.booksRepository.AddAsync(book);
            await this.booksRepository.SaveChangesAsync();

            return book.Id;
        }

        public Task<bool> DoesBookExistAsync(int id)
            => this.booksRepository
                .AllAsNoTracking()
                .AnyAsync(x => x.Id == id);

        public Task<T> GetByIdAsync<T>(int id)
            => this.booksRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.booksRepository
                .AllAsNoTracking()
                .To<T>()
                .ToListAsync();

        public async Task<IEnumerable<T>> GetByPageAsync<T>(int page)
            => await this.booksRepository
                .AllAsNoTracking()
                .To<T>()
                .Skip(page * GlobalConstants.BooksPerPage)
                .Take(GlobalConstants.BooksPerPage)
                .ToListAsync();

        public async Task<IEnumerable<T>> GetByPageWithCategoryAsync<T>(int page, int categoryId)
            => await this.booksRepository
                .AllAsNoTracking()
                .Where(x => x.BookCategories.Any(y => y.Category.Id == categoryId))
                .To<T>()
                .Skip(page * GlobalConstants.BooksPerPage)
                .Take(GlobalConstants.BooksPerPage)
                .ToListAsync();

        public Task<int> GetCountAsync()
            => this.booksRepository
                .AllAsNoTracking()
                .CountAsync();

        public Task<int> GetCountByCategoryAsync(int categoryId)
            => this.booksRepository
                .AllAsNoTracking()
                .CountAsync(x => x.BookCategories.Any(y => y.Category.Id == categoryId));

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
