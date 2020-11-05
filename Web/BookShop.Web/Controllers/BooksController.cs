namespace BookShop.Web.Controllers
{
    using ViewModels.Books;
    using Microsoft.AspNetCore.Mvc;

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
