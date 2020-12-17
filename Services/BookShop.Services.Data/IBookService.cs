namespace BookShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;

    public interface IBookService
    {
        Task<int> CreateBookAsync(AddBookViewModel model);

        Task<bool> DoesBookExistAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetByPageAsync<T>(int count);

        Task<IEnumerable<T>> GetByPageWithFilterAsync<T>(int count, Expression<Func<Book, bool>> filter);

        Task<int> GetCountAsync();

        Task<int> GetCountByFilterAsync(Expression<Func<Book, bool>> filter);
    }
}
