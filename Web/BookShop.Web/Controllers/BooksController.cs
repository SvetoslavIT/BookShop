namespace BookShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using BookShop.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;
    using BookShop.Common;
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
            => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(AddBookViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var bookId = await this.bookService.CreateBookAsync(inputModel);

            return this.RedirectToAction("Details", new { id = bookId });
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!await this.bookService.DoesBookExistAsync(id))
            {
                return this.NotFound();
            }

            var book = await this.bookService.GetByIdAsync<DetailsBookViewModel>(id);

            return this.View(book);
        }

        public async Task<IActionResult> All(int page = 0, string categoryName = GlobalConstants.DefaultCategoryName)
        {
            if (page < 0)
            {
                return this.BadRequest();
            }

            int count;
            IEnumerable<BookDto> books;

            if (categoryName == GlobalConstants.DefaultCategoryName)
            {
                count = await this.bookService.GetCountWithoutFilterAsync();
                books = await this.bookService.GetByPageWithoutFilterAsync<BookDto>(page);
            }
            else
            {
                Expression<Func<Book, bool>> filter =
                    x => x.BookCategories.Any(y => y.Category.Name.ToLower() == categoryName.ToLower());

                count = await this.bookService.GetCountWithFilterAsync(filter);
                books = await this.bookService.GetByPageWithFilterAsync<BookDto>(page, filter);
            }

            var pages = (int)Math.Ceiling(count / (double)GlobalConstants.BooksPerPage);
            var categories = await this.categoryService.GetAllAsync<CategoryDto>();

            var model = new AllBooksViewModel
            {
                Pages = pages,
                Books = books,
                Categories = categories,
                CurrentCategory = categoryName,
            };

            return this.View(model);
        }
    }
}
