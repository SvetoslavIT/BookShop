namespace BookShop.Services.Data
{
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Web.ViewModels.Comments;

    public interface ICommentService
    {
        Task<int> CreateAsync(CreateCommentModel model);

        Task<bool> DoesCommentExistAsync(int id);

        Task<Comment> DeleteAsync(int id);
    }
}
