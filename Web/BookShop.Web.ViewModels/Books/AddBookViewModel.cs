namespace BookShop.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookShop.Data.Models;
    using BookShop.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;
    using BookShop.Services.Mapping;

    using static BookShop.Common.ErrorMessages;
    using static BookShop.Common.GlobalConstants;

    public class AddBookViewModel : IMapTo<Book>
    {
        [Required(ErrorMessage = NotRequire)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InvalidBookName)]
        public string Name { get; set; }

        [Range(typeof(decimal), MinPrice, MaxPrice, ErrorMessage = InvalidPrice)]
        public decimal Price { get; set; }

        [Range(MinQuantity, MaxQuantity, ErrorMessage = InvalidQuantity)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [Range(MinPages, MaxPages, ErrorMessage = InvalidPages)]
        public int Pages { get; set; }

        public BookLanguage Language { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [StringLength(IsbnMaxLength, MinimumLength = IsbnMaxLength, ErrorMessage = InvalidIsbn)]
        public string Isbn { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [Range(MinYearOfIssue, MaxYearOfIssue, ErrorMessage = InvalidYear)]
        public int YearOfIssue { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [StringLength(AnnotationMaxLength, MinimumLength = AnnotationMinLength, ErrorMessage = InvalidAnnotation)]
        public string Annotation { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InvalidPublisherName)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [IsValidPhotos]
        public IEnumerable<IFormFile> Photos { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [IsAuthors]
        public string Authors { get; set; }

        [Required(ErrorMessage = NotRequire)]
        [IsCategories]
        public string Categories { get; set; }
    }
}
