namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using BookShop.Data.Common.Models;

    public class Purchase : BaseModel<int>
    {
        public decimal FinalPrice => this.Cart.Sum(x => x.Quantity * x.Book.Price);

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Cart> Cart { get; set; } = new HashSet<Cart>();
    }
}
