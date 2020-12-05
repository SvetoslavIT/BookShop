namespace BookShop.Web.ViewModels.Books
{
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class CategoryDto : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
