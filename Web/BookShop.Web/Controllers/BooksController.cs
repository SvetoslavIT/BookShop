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

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var bookId = await this.bookService.CreateBookAsync(inputModel);

            return this.RedirectToAction("Details", new { Id = bookId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.bookService.DoesBookExist(id))
            {
                return this.NotFound();
            }

            var book = await this.bookService.GetById<DetailsBookViewModel>(id);

            return this.View(book);
        }
    }
}
