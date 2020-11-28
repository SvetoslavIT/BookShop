namespace BookShop.Web.ViewModels.Books
{
    using System.Linq;

    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class AllBooksViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string[] Authors { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, AllBooksViewModel>()
                .ForMember(x => x.ImageUrl, y => y.MapFrom(x => x.Photos.First().Url))
                .ForMember(x => x.Authors, y => y.MapFrom(x => x.AuthorBooks.Select(z => z.Author.FullName)));
        }
    }
}
