namespace BookShop.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using BookShop.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;
    using BookShop.Common;

    public class BooksController : BaseController
    {
        private readonly IBookService books;
        private readonly ICategoryService categories;

        public BooksController(IBookService books, ICategoryService categories)
        {
            this.books = books;
            this.categories = categories;
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(AddBookViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var bookId = await this.books.CreateBookAsync(inputModel);

            return this.RedirectToAction(nameof(this.Details), new { id = bookId });
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await this.books.DoesBookExistAsync(id))
            {
                return this.NotFound();
            }

            var book = await this.books.GetByIdAsync<DetailsBookViewModel>(id);

            return this.View(book);
        }

        public async Task<IActionResult> All(int page = 0)
        {
            if (page < 0)
            {
                return this.BadRequest();
            }

            var count = await this.books.GetCountAsync();

            var pages = (int)Math.Ceiling(count / (double)GlobalConstants.BooksPerPage);
            var allBooks = await this.books.GetByPageAsync<BookDto>(page);
            var allCategories = await this.categories.GetAllAsync<CategoryDto>();

            var model = new AllBooksViewModel
            {
                Pages = pages,
                Books = allBooks,
                Categories = allCategories,
            };

            return this.View(model);
        }
    }
}
