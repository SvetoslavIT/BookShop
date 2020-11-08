namespace BookShop.Services.Data
{
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Books;

    public interface IBookService
    {
        Task<int> CreateBookAsync(AddBookViewModel model);

        Task<bool> DoesBookExist(int id);

        Task<T> GetById<T>(int id);
    }
}
