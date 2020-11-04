namespace BookShop.Services.Data
{
    using System.Threading.Tasks;

    using BookShop.Web.ViewModels.Books;

    public interface IBookService
    {
        Task<int> CreateBookAsync(AddBookViewModel model);
    }
}
