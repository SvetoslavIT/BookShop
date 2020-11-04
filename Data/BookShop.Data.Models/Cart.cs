namespace BookShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BookShop.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        public int Quantity { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
