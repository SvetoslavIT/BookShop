namespace BookShop.Web.ViewModels.Books
{
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class BookCategoryDto : IMapFrom<BookCategory>
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
