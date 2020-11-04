namespace BookShop.Web.Infrastructure.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using static BookShop.Common.ErrorMessages;
    using static BookShop.Common.GlobalConstants;

    public class IsAuthorsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var authors = value.ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            if (authors.Length < MinAuthors)
            {
                return new ValidationResult(InvalidAuthorsCount);
            }

            return authors
                .Any(x => x.Length < NameMinLength || x.Length > NameMaxLength) ?
                new ValidationResult(InvalidAuthorName) :
                ValidationResult.Success;
        }
    }
}
