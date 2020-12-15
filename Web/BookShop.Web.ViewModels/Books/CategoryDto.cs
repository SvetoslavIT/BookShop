namespace BookShop.Web.ViewModels.Books
{
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
