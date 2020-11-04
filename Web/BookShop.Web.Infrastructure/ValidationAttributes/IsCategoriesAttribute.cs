namespace BookShop.Web.Infrastructure.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using static BookShop.Common.ErrorMessages;
    using static BookShop.Common.GlobalConstants;

    public class IsCategoriesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categories = value.ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            if (categories.Length < MinCategories)
            {
                return new ValidationResult(InvalidCategoriesCount);
            }

            return categories
                .Any(x => x.Length < NameMinLength || x.Length > NameMaxLength) ?
                new ValidationResult(InvalidCategoryName) :
                ValidationResult.Success;
        }
    }
}
