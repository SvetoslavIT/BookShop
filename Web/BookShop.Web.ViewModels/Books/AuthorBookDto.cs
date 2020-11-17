namespace BookShop.Web.ViewModels.Books
{
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class AuthorBookDto : IMapFrom<AuthorBook>
    {
        public int AuthorId { get; set; }

        public string AuthorFullName { get; set; }
    }
}
