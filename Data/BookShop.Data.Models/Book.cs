namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using BookShop.Common;
    using BookShop.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Pages { get; set; }

        public BookLanguage Language { get; set; }

        [Required]
        [MaxLength(GlobalConstants.IsbnMaxLength)]
        public string Isbn { get; set; }

        public int Bought { get; set; }

        public int YearOfIssue { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AnnotationMaxLength)]
        public string Annotation { get; set; }

        public int PublisherId { get; set; }

        [IgnoreMap]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        [IgnoreMap]
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new HashSet<AuthorBook>();

        public virtual ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();
    }
}
