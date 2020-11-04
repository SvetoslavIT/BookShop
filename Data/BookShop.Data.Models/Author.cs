namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookShop.Common;
    using BookShop.Data.Common.Models;

    public class Author : BaseModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string FullName { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new HashSet<AuthorBook>();
    }
}
