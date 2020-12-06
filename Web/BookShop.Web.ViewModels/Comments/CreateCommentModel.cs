namespace BookShop.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using BookShop.Common;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    using static BookShop.Common.ErrorMessages;
    using static BookShop.Common.GlobalConstants;

    public class CreateCommentModel : IMapTo<Comment>
    {
        [Required(ErrorMessage = NotRequire)]
        [StringLength(DescriptionMaxLength, MinimumLength = DefaultMinLength, ErrorMessage = InvalidDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = NotRequire)]
        public int BookId { get; set; }

        [Required(ErrorMessage = NotRequire)]
        public string UserId { get; set; }
    }
}
