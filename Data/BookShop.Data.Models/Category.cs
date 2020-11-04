namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BookShop.Common;
    using BookShop.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();
    }
}
