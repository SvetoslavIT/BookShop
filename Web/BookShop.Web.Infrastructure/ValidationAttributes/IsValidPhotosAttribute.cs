namespace BookShop.Web.Infrastructure.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookShop.Common;
    using Microsoft.AspNetCore.Http;

    public class IsValidPhotosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var photos = (IEnumerable<IFormFile>)value;

            var validExtensions = new[] { ".jpe", ".jpeg", ".png" };

            foreach (var photo in photos)
            {
                var isValid = false;

                foreach (var validExtension in validExtensions)
                {
                    if (photo.FileName.EndsWith(validExtension))
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    return new ValidationResult(ErrorMessages.InvalidPhoto);
                }
            }

            return ValidationResult.Success;
        }
    }
}