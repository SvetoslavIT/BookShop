namespace BookShop.Web.ViewModels.Books
{
    using System.Collections.Generic;

    public class AllBooksViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        public int Pages { get; set; }

        public string CurrentCategory { get; set; }
    }
}
