namespace BookShop.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using BookShop.Common;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;
    using BookShop.Web.ViewModels.Books;

    public class CategoriesController : Controller
    {
        private readonly IBookService books;
        private readonly ICategoryService categories;

        public CategoriesController(IBookService books, ICategoryService categories)
        {
            this.books = books;
            this.categories = categories;
        }

        public async Task<IActionResult> All(int id, int page = 0)
        {
            if (page < 0 ||
                !await this.categories.DoesCategoryExistAsync(id))
            {
                return this.BadRequest();
            }
            var count = await this.books.GetCountByCategoryAsync(id);

            var pages = (int)Math.Ceiling(count / (double)GlobalConstants.BooksPerPage);
            var allBooks = await this.books.GetByPageWithCategoryAsync<BookDto>(page, id);
            var allCategories = await this.categories.GetAllAsync<CategoryDto>();
            this.ViewData["CategoryId"] = id;
            this.ViewData["CategoryName"] = await this.categories.GetNameByIdAsync(id);

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
