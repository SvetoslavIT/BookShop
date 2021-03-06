﻿namespace BookShop.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using BookShop.Common;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;
    using BookShop.Web.ViewModels.Books;
    using BookShop.Web.ViewModels.Categories;
    using BookShop.Data.Models;

    public class CategoriesController : BaseController
    {
        private readonly IBookService books;
        private readonly ICategoryService categories;

        public CategoriesController(IBookService books, ICategoryService categories)
        {
            this.books = books;
            this.categories = categories;
        }

        public async Task<IActionResult> AllBooks(int id, int page = 0)
        {
            if (page < 0 ||
                !await this.categories.DoesCategoryExistAsync(id))
            {
                return this.BadRequest();
            }

            Expression<Func<Book, bool>> filter = x => x.BookCategories.Any(y => y.CategoryId == id);

            var count = await this.books.GetCountByFilterAsync(filter);

            var pages = (int)Math.Ceiling(count / (double)GlobalConstants.BooksPerPage);
            var allBooks = await this.books.GetByPageWithFilterAsync<BookDto>(page, filter);
            var allCategories = await this.categories.GetAllAsync<CategoryDto>();
            var categoryName = await this.categories.GetNameByIdAsync(id);

            var booksModel = new AllBooksViewModel
            {
                Pages = pages,
                Books = allBooks,
                Categories = allCategories,
            };

            var model = new AllBooksByCategoryViewModel
            {
                CategoryId = id,
                CategoryName = categoryName,
                BooksModel = booksModel,
            };

            return this.View(model);
        }
    }
}
