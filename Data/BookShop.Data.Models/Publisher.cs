namespace BookShop.Data.Models
{
    using System.Collections.Generic;

    using BookShop.Data.Common.Models;

    public class Publisher : BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
