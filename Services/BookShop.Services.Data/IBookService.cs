namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BookShop.Web.ViewModels.Books;

    public interface IBookService
    {
        Task<int> CreateBookAsync(AddBookViewModel model);

        Task<bool> DoesBookExistAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetByPageAsync<T>(int count);

        Task<IEnumerable<T>> GetByPageWithCategoryAsync<T>(int count, int categoryId);

        Task<int> GetCountAsync();

        Task<int> GetCountByCategoryAsync(int categoryId);
    }
}
