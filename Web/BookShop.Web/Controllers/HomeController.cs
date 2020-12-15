namespace BookShop.Web.Controllers
{
    using System.Diagnostics;

    using BookShop.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index() => this.View();

        [HttpGet]
        public IActionResult Privacy() => this.View();

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });

        [HttpGet]
        public IActionResult HttpError(int statusCode) => this.View(statusCode);
    }
}
