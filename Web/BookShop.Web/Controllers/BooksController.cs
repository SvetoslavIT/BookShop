namespace BookShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Books;

    public class BooksController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AddBookViewModel inputModel)
        {
            return this.RedirectToAction("Index", "Create");
        }
    }
}
