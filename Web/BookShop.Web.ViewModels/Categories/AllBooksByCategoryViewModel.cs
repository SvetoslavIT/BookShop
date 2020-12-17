namespace BookShop.Web.ViewModels.Categories
{
    using BookShop.Web.ViewModels.Books;

    public class AllBooksByCategoryViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public AllBooksViewModel BooksModel { get; set; }
    }
}
