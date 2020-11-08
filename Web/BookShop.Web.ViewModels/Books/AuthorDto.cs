namespace BookShop.Web.ViewModels.Books
{
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class AuthorDto : IMapFrom<AuthorBook>
    {
        public int AuthorId { get; set; }

        public Author AuthorFullName { get; set; }
    }
}