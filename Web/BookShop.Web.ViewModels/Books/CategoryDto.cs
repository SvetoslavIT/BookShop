namespace BookShop.Web.ViewModels.Books
{
    using Data.Models;
    using Services.Mapping;

    public class CategoryDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}