namespace BookShop.Web.ViewModels.Books
{
    using System.Linq;

    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class DetailsBookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Pages { get; set; }

        public string Language { get; set; }

        public string Isbn { get; set; }

        public int Bought { get; set; }

        public int YearOfIssue { get; set; }

        public string Annotation { get; set; }

        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        public CommentDto[] Comments { get; set; }

        public string[] Photos { get; set; }

        public AuthorDto[] Authors { get; set; }

        public CategoryDto[] Categories { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, DetailsBookViewModel>()
                .ForMember(x => x.Language, y => y.MapFrom(x => x.Language.ToString()))
                .ForMember(x => x.Photos, y => y.MapFrom(x => x.Photos.Select(z => z.Url)))
                .ForMember(x => x.Categories, y => y.MapFrom(x => x.BookCategories.Select(z => z.Category.Name)));
        }
    }
}
