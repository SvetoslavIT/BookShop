namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;

    public interface IBookService
    {
        Task<int> CreateBookAsync(AddBookViewModel model);

        Task<bool> DoesBookExist(int id);

        Task<T> GetById<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetByPage<T>(int count);

        Task<int> GetCountAsync();
    }
}
