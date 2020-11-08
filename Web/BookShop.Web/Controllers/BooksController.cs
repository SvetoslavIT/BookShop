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

            return this.RedirectToAction("Index", "Home");
        }
    }
}
