namespace BookShop.Web.ViewModels.Authors
{
    using BookShop.Web.ViewModels.Books;

    public class AllBooksByAuthorViewModel
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public AllBooksViewModel BooksModel { get; set; }
    }
}
