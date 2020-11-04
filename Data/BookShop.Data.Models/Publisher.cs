namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookShop.Common;
    using BookShop.Data.Common.Models;

    public class Publisher : BaseModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
