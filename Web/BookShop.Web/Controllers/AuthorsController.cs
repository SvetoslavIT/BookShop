namespace BookShop.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using BookShop.Common;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Web.ViewModels.Books;
    using BookShop.Services.Data;
    using Data.Models;
    using ViewModels.Authors;

    public class AuthorsController : BaseController
    {
        private readonly IBookService books;
        private readonly ICategoryService categories;
        private readonly IAuthorService authors;

        public AuthorsController(
            IBookService books,
            ICategoryService categories,
            IAuthorService authors)
        {
            this.books = books;
            this.categories = categories;
            this.authors = authors;
        }

        public async Task<IActionResult> AllBooks(int id, int page = 0)
        {
            if (page < 0)
            {
                return this.BadRequest();
            }

            Expression<Func<Book, bool>> filter = x => x.AuthorBooks.Any(y => y.AuthorId == id);

            var count = await this.books.GetCountByFilterAsync(filter);

            var pages = (int)Math.Ceiling(count / (double)GlobalConstants.BooksPerPage);
            var allBooks = await this.books.GetByPageWithFilterAsync<BookDto>(page, filter);
            var allCategories = await this.categories.GetAllAsync<CategoryDto>();
            var name = await this.authors.GetNameByIdAsync(id);

            var booksModel = new AllBooksViewModel
            {
                Pages = pages,
                Books = allBooks,
                Categories = allCategories,
            };

            var model = new AllBooksByAuthorViewModel
            {
                AuthorId = id,
                AuthorName = name,
                BooksModel = booksModel,
            };

            return this.View(model);
        }
    }
}
