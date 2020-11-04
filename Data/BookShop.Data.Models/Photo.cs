namespace BookShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BookShop.Common;
    using BookShop.Data.Common.Models;

    public class Photo : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UrlMaxLength)]
        public string Url { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
