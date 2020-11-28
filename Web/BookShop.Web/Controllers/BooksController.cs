namespace BookShop.Web.Controllers
{
    using System.Threading.Tasks;

    using BookShop.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;

    public class BooksController : BaseController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
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
            if (!await this.bookService.DoesBookExist(id))
            {
                return this.NotFound();
            }

            var book = await this.bookService.GetById<DetailsBookViewModel>(id);

            return this.View(book);
        }

        public async Task<IActionResult> All(int page = 0)
        {
            if (page < 0)
            {
                return this.BadRequest();
            }

            var books = await this.bookService.GetByPage<AllBooksViewModel>(page);

            return this.View(books);
        }
    }
}
